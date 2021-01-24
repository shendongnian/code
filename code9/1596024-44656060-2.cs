    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace Testing_multiple_events
    {
        public partial class Form1 : Form
        {
            int activeWindowCount = 1;
            int activeMouseClickCount = 1;
            public Form1()
            {                
                InitializeComponent();
                // set up the global hook event for change of active window
                GlobalEventHook.Start();               
                GlobalEventHook.WinEventActive += new EventHandler(GlobalEventHook_WinEventActive);                        
    
                // Setup global mouse hook to react to mouse clicks under certain conditions, see event handler
                MouseHook.Start();
                MouseHook.MouseAction += new EventHandler(MouseHook_MouseAction);
            }
       
            private void GlobalEventHook_WinEventActive(object sender, EventArgs e)
            {
                richTextBox1.AppendText("Active Window Change Global Hook Triggered: " + activeWindowCount + "\r\n");
                activeWindowCount++;
            }    
            private void MouseHook_MouseAction(object sender, EventArgs e)
            {
                richTextBox1.AppendText("Global MouseHook Triggered: " + activeMouseClickCount + "\r\n");
                activeMouseClickCount++;
            }
        }
    }
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace Testing_multiple_events
    {
        public static class GlobalEventHook
        {
            [DllImport("user32.dll")]
            internal static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc,
                WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);
    
            [DllImport("user32.dll")]
            internal static extern bool UnhookWinEvent(IntPtr hWinEventHook);
    
            public static event EventHandler WinEventActive = delegate { };
            public static event EventHandler WinEventContentScrolled = delegate { };
    
            public delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject,
                int idChild, uint dwEventThread, uint dwmsEventTime);
    
            private static WinEventDelegate dele = null;
            private static IntPtr _hookID = IntPtr.Zero;
    
    
    
            public static void Start()
            {
                dele = new WinEventDelegate(WinEventProc);
                _hookID = SetWinEventHook(Win32API.EVENT_SYSTEM_FOREGROUND, Win32API.EVENT_OBJECT_CONTENTSCROLLED, IntPtr.Zero, dele, 0, 0, Win32API.WINEVENT_OUTOFCONTEXT);
            }
    
            public static void stop()
            {
                UnhookWinEvent(_hookID);
            }
    
            public static void restart()
            {
    
                _hookID = SetWinEventHook(Win32API.EVENT_SYSTEM_FOREGROUND, Win32API.EVENT_OBJECT_CONTENTSCROLLED, IntPtr.Zero, dele, 0, 0, Win32API.WINEVENT_OUTOFCONTEXT);
            }
    
            public static void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
            {
                
                    if (eventType == Win32API.EVENT_SYSTEM_FOREGROUND)
                    {                       
                        WinEventActive(null, new EventArgs());
                    }
            }
    }
    }
    
        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    
    namespace Testing_multiple_events
    {
        public static class MouseHook
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int idHook,
              LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
              IntPtr wParam, IntPtr lParam);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);
    
            public static event EventHandler MouseAction = delegate { };
    
            private const int WH_MOUSE_LL = 14;
    
            private enum MouseMessages
            {
                WM_LBUTTONDOWN = 0x0201,
                WM_LBUTTONUP = 0x0202,
                WM_MOUSEMOVE = 0x0200,
                WM_MOUSEWHEEL = 0x020A,
                WM_RBUTTONDOWN = 0x0204,
                WM_RBUTTONUP = 0x0205
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private struct POINT
            {
                public int x;
                public int y;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private struct MSLLHOOKSTRUCT
            {
                public POINT pt;
                public uint mouseData;
                public uint flags;
                public uint time;
                public IntPtr dwExtraInfo;
            }
    
            public static void Start()
            {
                _hookID = SetHook(_proc);
                
            }
            public static void stop()
            {
                UnhookWindowsHookEx(_hookID);
            }
    
            private static LowLevelMouseProc _proc = HookCallback;
            private static IntPtr _hookID = IntPtr.Zero;
    
            private static IntPtr SetHook(LowLevelMouseProc proc)
            {
                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    IntPtr hook = SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle("user32"), 0);
                    if (hook == IntPtr.Zero) throw new System.ComponentModel.Win32Exception();
                    return hook;
                }
            }
    
            private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
    
            private static IntPtr HookCallback(
              int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0 && (MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam || MouseMessages.WM_RBUTTONDOWN == (MouseMessages)wParam || 
                    MouseMessages.WM_MOUSEWHEEL == (MouseMessages)wParam))
                {
                    MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                    MouseAction(null, new EventArgs());
                }
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }
    
        }
    }
