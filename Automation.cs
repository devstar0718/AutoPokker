using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        private IntPtr hWnd = IntPtr.Zero;
        private StringBuilder strResult = new StringBuilder();
        private void BtnRun_Click(object sender, EventArgs e)
        {
            try
            {
                strResult.Clear();
                SelectApplication();

                SelectFirstItemOnFlop();
                SendKeys.SendWait("{DOWN}");
                CopyAbsStrategy();
                SendKeys.SendWait("{RIGHT}");
                CopyAbsStrategyFromFlop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            File.WriteAllText("Result.txt", strResult.ToString());
            TBResult.Text = strResult.ToString();
        }
        private void CopyAbsStrategyFromFlop()
        {
            int x, y;
            for (int i = 0; i < 3; i++)
            {
                y = 700 + 70 * i;
                for (int j = 0; j < 13; j++)
                {
                    x = 200 + j * 50;
                    SelectSecondItemOnFlop();
                    CopyAbsStrategy();
                    SelectTurnCard(x, y);

                    SelectFirstItemOnTurn();
                    SendKeys.SendWait("{DOWN}");
                    CopyAbsStrategy();
                    SendKeys.SendWait("{RIGHT}");
                    CopyAbsStrategyFromTurn();
                }
            }
        }
        private void CopyAbsStrategyFromTurn()
        {
            int x, y;
            for(int i = 0; i < 3; i++)
            {
                y = 700 + i * 70;
                for(int j = 0; j < 13; j++)
                {
                    x = 270 + j * 50;
                    SelectSecondItemOnTurn();
                    CopyAbsStrategy();
                    SelectRiverCard(x, y);
                    SelectSecondItemOnTurn();

                    CalculateRiver();

                    SelectFirstItemOnRiver();
                    CopyAbsStrategyFromRiver();
                }
            }
        }
        private void CopyAbsStrategyFromRiver()
        {
            SendKeys.SendWait("{DOWN}");
            CopyAbsStrategy();
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{DOWN}");
            CopyAbsStrategy();
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{RIGHT}");
            SendKeys.SendWait("{DOWN}");
            CopyAbsStrategy();
            for(int i = 0; i < 11; i++)
            {
                SendKeys.SendWait("{DOWN}");
                SendKeys.SendWait("{DOWN}");
                SendKeys.SendWait("{RIGHT}");
                SendKeys.SendWait("{DOWN}");
                CopyAbsStrategy();
            }
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
            if(hWnd != GetForegroundWindow())
            {
                throw new Exception("Application not focused");
            }
            SendKeys.SendWait("^+{F10}");
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{DOWN}");
            SendKeys.SendWait("{ENTER}");                                   // select 4th item on context menu - that's "Copy Abs. Strategy"
            Thread.Sleep(Convert.ToInt32(NUDDelayCopy.Value));                                              // need to wait for copy data to clipboard
            strResult.AppendLine(Clipboard.GetText());
            strResult.AppendLine();
        }
        private void SelectFirstItemOnFlop()
        {
            ClickOnPointTool.ClickOnPoint(hWnd, new Point(200, 750));
            DelayForMouseSelection();
        }
        private void SelectSecondItemOnFlop()
        {
            ClickOnPointTool.ClickOnPoint(hWnd, new Point(200, 780));
            DelayForMouseSelection();
        }
        private void SelectFirstItemOnTurn()
        {
            ClickOnPointTool.ClickOnPoint(hWnd, new Point(600, 750));
            DelayForMouseSelection();
        }
        private void SelectSecondItemOnTurn()
        {
            ClickOnPointTool.ClickOnPoint(hWnd, new Point(600, 780));
            DelayForMouseSelection();
        }
        private void SelectFirstItemOnRiver()
        {
            ClickOnPointTool.ClickOnPoint(hWnd, new Point(1000, 750));
            DelayForMouseSelection();
        }
        private void SelectTurnCard(int x, int y)
        {
            ClickOnPointTool.ClickOnPoint(hWnd, new Point(200, 600));
            DelayForMouseSelection();
            ClickOnPointTool.ClickOnPoint(hWnd, new Point(x, y), true, false);
            DelayForMouseSelection();
            ClickOnPointTool.ClickOnPoint(hWnd, new Point(200, 550));
            DelayForMouseSelection();
        }
        private void SelectRiverCard(int x, int y)
        {
            ClickOnPointTool.ClickOnPoint(hWnd, new Point(250, 600));
            DelayForMouseSelection();
            ClickOnPointTool.ClickOnPoint(hWnd, new Point(x, y), true, false);
            DelayForMouseSelection();
            ClickOnPointTool.ClickOnPoint(hWnd, new Point(200, 550));
            DelayForMouseSelection();
        }
        private void CalculateRiver()
        {
            ClickOnPointTool.ClickOnPoint(hWnd, new Point(1100, 670));
            Thread.Sleep(Convert.ToInt32(NUDDelayRiver.Value));
        }
        private void DelayForMouseSelection(int scale = 1)
        {
            Thread.Sleep(Convert.ToInt32(NUDDelayMouse.Value) * scale);
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


            public static void ClickOnPoint(IntPtr wndHandle, Point clientPoint, bool mouseDown = true, bool mouseUp = true, bool leftButton = true)
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

                List<INPUT> inputs = new List<INPUT>();
                if (mouseDown)
                {
                    inputs.Add(inputMouseDown);
                }
                if (mouseUp)
                {
                    inputs.Add(inputMouseUp);
                }
                if(inputs.Count > 0)
                    SendInput((uint)inputs.Count, inputs.ToArray(), Marshal.SizeOf(typeof(INPUT)));
                /// return mouse 
                Cursor.Position = oldPos;
            }

        }
        private void TBResult_KeyDown(object sender, KeyEventArgs e)
        {
        }
    }
}
