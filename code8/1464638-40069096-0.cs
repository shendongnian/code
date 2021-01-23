    using System;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr GetCurrentProcess();
    
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool CloseHandle(IntPtr hHandle);
    
            [StructLayout(LayoutKind.Sequential)]
            public struct LUID
            {
                public UInt32 LowPart;
                public Int32 HighPart;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            public struct TOKEN_PRIVILEGES
            {
                public UInt32 PrivilegeCount;
                public LUID Luid;
                public UInt32 Attributes;
            }
    
            [DllImport("advapi32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool OpenProcessToken(IntPtr ProcessHandle,
                UInt32 DesiredAccess, out IntPtr TokenHandle);
    
            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool LookupPrivilegeValue(string lpSystemName, string lpName,
                out LUID lpLuid);
    
            // Use this signature if you do not want the previous state
            [DllImport("advapi32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool AdjustTokenPrivileges(IntPtr TokenHandle,
               [MarshalAs(UnmanagedType.Bool)]bool DisableAllPrivileges,
               ref TOKEN_PRIVILEGES NewState,
               UInt32 Zero,
               IntPtr Null1,
               IntPtr Null2);
    
            private static uint TOKEN_QUERY = 0x0008;
            private static uint TOKEN_ADJUST_PRIVILEGES = 0x0020;
    
            public const UInt32 SE_PRIVILEGE_ENABLED = 0x00000002;
    
            public const string SE_SYSTEMTIME_NAME = "SeSystemtimePrivilege";
    
            static void Main(string[] args)
            {
                IntPtr hToken;
                string sSEPrivilegeName = SE_SYSTEMTIME_NAME;
                LUID luidSEPrivilegeNameValue;
                TOKEN_PRIVILEGES tkpPrivileges;
    
                if (!OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, out hToken))
                {
                    Console.WriteLine("OpenProcessToken() failed, error = {0}. {1} is not available", Marshal.GetLastWin32Error(), sSEPrivilegeName);
                    return;
                }
                else
                {
                    Console.WriteLine("OpenProcessToken() successfully");
                }
    
                if (!LookupPrivilegeValue(null, SE_SYSTEMTIME_NAME, out luidSEPrivilegeNameValue))
                {
                    Console.WriteLine("LookupPrivilegeValue() failed, error = {0}. {1} is not available", Marshal.GetLastWin32Error(), sSEPrivilegeName);
                    CloseHandle(hToken);
                    return;
                }
                else
                {
                    Console.WriteLine("LookupPrivilegeValue() successfully");
                }
    
                tkpPrivileges.PrivilegeCount = 1;
                tkpPrivileges.Luid = luidSEPrivilegeNameValue;
                tkpPrivileges.Attributes = SE_PRIVILEGE_ENABLED;
    
                if (!AdjustTokenPrivileges(hToken, false, ref tkpPrivileges, 0, IntPtr.Zero, IntPtr.Zero))
                {
                    Console.WriteLine("LookupPrivilegeValue() failed, error = {0}. {1} is not available", Marshal.GetLastWin32Error(), sSEPrivilegeName);
                }
                else
                {
                    Console.WriteLine("{0} is now available", sSEPrivilegeName);
                }
                CloseHandle(hToken);
                Console.ReadLine();
            }
        }
    }
