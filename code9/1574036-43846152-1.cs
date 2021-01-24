    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace KeyHook {
        public class KeyHook {
            const int WH_KEYBOARD_LL = 13;
    
            const int WM_KEYDOWN = 0x0100;
            const int WM_KEYUP = 0x0101;
    
            delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
    
            LowLevelKeyboardProc _proc { get; set; }
    
            IntPtr _hookID { get; set; }
    
            public delegate void KeyHandler(Keys k);
            public event KeyHandler OnKeyDown;
            public event KeyHandler OnKeyUp;
    
            public KeyHook() {
                Initialize();
                _hookID = SetHook(_proc);
            }
    
            void Initialize() {
                this._proc = HookCallback;
                this._hookID = IntPtr.Zero;
                Application.ApplicationExit += Application_ApplicationExit;
            }
    
            void Application_ApplicationExit(object sender, EventArgs e) {
                UnhookWindowsHookEx(_hookID);
            }
    
            IntPtr SetHook(LowLevelKeyboardProc proc) {
                using (Process curProcess = Process.GetCurrentProcess()) {
                    using (ProcessModule curModule = curProcess.MainModule) {
                        return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle
    
    (curModule.ModuleName), 0);
                    }
                }
            }
    
            IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam) {
                if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN) {
                    if (this.OnKeyDown != null) {
                        this.OnKeyDown((Keys)Marshal.ReadInt32(lParam));
                    }
                } else if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP) {
                    if (this.OnKeyUp != null) {
                        this.OnKeyUp((Keys)Marshal.ReadInt32(lParam));
                    }
                }
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }
    
            #region dll Imports
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, 
    
    uint dwThreadId);
    
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool UnhookWindowsHookEx(IntPtr hhk);
    
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
    
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern IntPtr GetModuleHandle(string lpModuleName);
            #endregion
        }
    }
