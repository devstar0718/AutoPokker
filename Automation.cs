using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automation
{
    public partial class Automation : Form
    {
        public Automation()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private IntPtr hWnd = IntPtr.Zero;
        private StringBuilder strResult = new StringBuilder();
        private const int tDelay = 100;
        private void BtnRun_Click(object sender, EventArgs e)
        {
            SelectApplication();
            SelectFirstItemOnFlop();
            SendKeys.SendWait("{DOWN}");
            CopyAbsStrategy();
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{DOWN}");
            ClickOnPointTool.ClickOnPoint(hWnd, new Point(200, 780));       // set focus to tree view by mouse left click
            Thread.Sleep(tDelay);
            CopyAbsStrategy();
            TBResult.Text = strResult.ToString();
            SelectFourthCard();
        }
        private void SelectApplication()
        {
            var processes = Process.GetProcesses();

            foreach (var process in processes)
            {
                if (process.ProcessName == "SimplePostflop")                 // find Simple Postflop Application
                {
                    hWnd = process.MainWindowHandle;
                    break;
                }
            }
            if (hWnd == IntPtr.Zero)
            {
                MessageBox.Show("Please open \"Simple Postflop\" application first");
                return;
            }
            SetForegroundWindow(hWnd);
        }
        private void CopyAbsStrategy()
        {
            SendKeys.SendWait("^+{F10}");
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{ENTER}");                                   // select 4th item on context menu - that's "Copy Abs. Strategy"
            Thread.Sleep(tDelay);                                              // need to wait for copy data to clipboard
            strResult.AppendLine(Clipboard.GetText());
            strResult.AppendLine();
        }
        private void SelectFirstItemOnFlop()
        {
            ClickOnPointTool.ClickOnPoint(hWnd, new Point(200, 750));       // set focus to tree view by mouse left click
            Thread.Sleep(tDelay);
        }
        private void SelectFourthCard()
        {
            ClickOnPointTool.ClickOnPoint(hWnd, new Point(200, 600));
            Thread.Sleep(tDelay);
            ClickOnPointTool.ClickOnPoint(hWnd, new Point(200, 700), false);
            Thread.Sleep(tDelay);
            ClickOnPointTool.ClickOnPoint(hWnd, new Point(200, 550));
            Thread.Sleep(tDelay);
        }

        public class ClickOnPointTool
        {

            [DllImport("user32.dll")]
            static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

            [DllImport("user32.dll")]
            internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

#pragma warning disable 649
            internal struct INPUT
            {
                public UInt32 Type;
                public MOUSEKEYBDHARDWAREINPUT Data;
            }

            [StructLayout(LayoutKind.Explicit)]
            internal struct MOUSEKEYBDHARDWAREINPUT
            {
                [FieldOffset(0)]
                public MOUSEINPUT Mouse;
            }

            internal struct MOUSEINPUT
            {
                public Int32 X;
                public Int32 Y;
                public UInt32 MouseData;
                public UInt32 Flags;
                public UInt32 Time;
                public IntPtr ExtraInfo;
            }

#pragma warning restore 649


            public static void ClickOnPoint(IntPtr wndHandle, Point clientPoint, bool mouseUp = true, bool leftButton = true)
            {
                var oldPos = Cursor.Position;

                /// get screen coordinates
                ClientToScreen(wndHandle, ref clientPoint);

                /// set cursor on coords, and press mouse
                Cursor.Position = new Point(clientPoint.X, clientPoint.Y);

                var inputMouseDown = new INPUT();
                inputMouseDown.Type = 0; /// input type mouse
                inputMouseDown.Data.Mouse.Flags = 0x0002; /// left button down

                var inputMouseUp = new INPUT();
                inputMouseUp.Type = 0; /// input type mouse
                inputMouseUp.Data.Mouse.Flags = 0x0004; /// left button up

                if (!leftButton)
                {
                    inputMouseDown.Data.Mouse.Flags = 0x0008; /// left button down
                    inputMouseUp.Data.Mouse.Flags = 0x00010; /// left button up
                }

                if (mouseUp)
                {
                    var inputs = new INPUT[] { inputMouseDown, inputMouseUp };
                    SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
                }
                else
                {
                    var inputs = new INPUT[] { inputMouseDown};
                    SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));
                }

                /// return mouse 
                Cursor.Position = oldPos;
            }

        }

        private void TBResult_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
