    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    namespace ManageScreenSaver.MediaElementWpf
    {
        public static class NativeMethods
        {
            public const uint SPI_GETSCREENSAVETIMEOUT = 0x000E;
            public const uint SPI_SETSCREENSAVETIMEOUT = 0x000F;
            public const uint SPI_GETSCREENSAVEACTIVE = 0x0010;
            public const uint SPI_SETSCREENSAVEACTIVE = 0x0011;
            public const uint SPI_SETSCREENSAVERRUNNING = 0x0061;
            public const uint SPI_SCREENSAVERRUNNING = SPI_SETSCREENSAVERRUNNING;
            public const uint SPI_GETSCREENSAVERRUNNING = 0x0072;
            public const uint SPI_GETSCREENSAVESECURE = 0x0076;
            public const uint SPI_SETSCREENSAVESECURE = 0x0077;
            public const uint SPIF_UPDATEINIFILE = 0x0001;
            public const uint SPIF_SENDWININICHANGE = 0x0002;
            public const uint SPIF_SENDCHANGE = SPIF_SENDWININICHANGE;
            [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, PreserveSig = true, SetLastError = true)]
            internal static unsafe extern bool SystemParametersInfo(uint  uiAction, uint  uiParam, void* pvParam, uint  fWinIni);
            [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, PreserveSig = true, SetLastError = true)]
            internal static extern IntPtr DefWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled);
            [DllImport("user32.dll", SetLastError = true)]
            static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);
            [DllImport("User32.dll", SetLastError = true)]
            internal static extern int SendMessage(IntPtr hWnd, uint msg, uint wParam, uint lParam);
            [DllImport("user32.dll", SetLastError = true)]
            internal static extern bool LockWorkStation();
            public static TimeSpan GetLastUserInputTimeInterval()
            {
                LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
                lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
                if (!GetLastInputInfo(ref lastInputInfo))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                uint ticks = (uint)Environment.TickCount;
                var idleMiliseconds = ticks - lastInputInfo.dwTime;
                return idleMiliseconds > 0 ? TimeSpan.FromMilliseconds((double)idleMiliseconds) : default(TimeSpan);
            }
            public static void LockWorkStationSession()
            {
                if (!LockWorkStation())
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
            public static bool IsScreenSaverActive
            {
                get
                {
                    bool enabled = false;
                    unsafe
                    {
                        var result = SystemParametersInfo(SPI_GETSCREENSAVEACTIVE, 0, &enabled, 0);
                        if (!result)
                        {
                            throw new Win32Exception(Marshal.GetLastWin32Error());
                        }
                        return enabled;
                    }
                }
            }
            public static bool IsScreenSaverRunning
            {
                get
                {
                    bool enabled = false;
                    unsafe
                    {
                        var result = SystemParametersInfo(SPI_GETSCREENSAVERRUNNING, 0, &enabled, 0);
                        if (!result)
                        {
                            throw new Win32Exception(Marshal.GetLastWin32Error());
                        }
                        return enabled;
                    }
                }
            }
            public static bool IsScreenSaverSecure
            {
                get
                {
                    bool enabled = false;
                    unsafe
                    {
                        var result = SystemParametersInfo(SPI_GETSCREENSAVESECURE, 0, &enabled, 0);
                        if (!result)
                        {
                            throw new Win32Exception(Marshal.GetLastWin32Error());
                        }
                        return enabled;
                    }
                }
            }
            public static TimeSpan ScreenSaverTimeout
            {
                get
                {
                    int timeout = 0;
                    unsafe
                    {
                        var result = SystemParametersInfo(SPI_GETSCREENSAVETIMEOUT, 0, &timeout, 0);
                        if (!result)
                        {
                            throw new Win32Exception(Marshal.GetLastWin32Error());
                        }
                        return TimeSpan.FromSeconds(timeout);
                    }
                }
            }
        }
        
        [Flags]
        public enum WindowMessage : uint
        {
            WM_COMMAND = 0x0111,
            WM_SYSCOMMAND = 0x0112, 
        }
        
        public enum WmSysCommandParam : uint
        {
            ScSIZE        = 0xF000,
            ScMOVE        = 0xF010,
            ScMINIMIZE    = 0xF020,
            ScMAXIMIZE    = 0xF030,
            ScNEXTWINDOW  = 0xF040,
            ScPREVWINDOW  = 0xF050,
            ScCLOSE       = 0xF060,
            ScVSCROLL     = 0xF070,
            ScHSCROLL     = 0xF080,
            ScMOUSEMENU   = 0xF090,
            ScKEYMENU     = 0xF100,
            ScARRANGE     = 0xF110,
            ScRESTORE     = 0xF120,
            ScTASKLIST    = 0xF130,
            ScSCREENSAVE  = 0xF140,
            ScHOTKEY      = 0xF150,
            ScDEFAULT     = 0xF160,
            ScMONITORPOWER= 0xF170,
            ScCONTEXTHELP = 0xF180,
            ScSEPARATOR   = 0xF00F,
        }
     }   
        
