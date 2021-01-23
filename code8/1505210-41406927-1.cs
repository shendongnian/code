        // Structures needed by CreateProcess API
        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public uint dwProcessId;
            public uint dwThreadId;
        }
        public struct STARTUPINFO
        {
            public uint cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public uint dwX;
            public uint dwY;
            public uint dwXSize;
            public uint dwYSize;
            public uint dwXCountChars;
            public uint dwYCountChars;
            public uint dwFillAttribute;
            public uint dwFlags;
            public short wShowWindow;
            public short cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }
        public struct SECURITY_ATTRIBUTES
        {
            public int length;
            public IntPtr lpSecurityDescriptor;
            public bool bInheritHandle;
        }
        public class MyProcess : IDisposable
        {
            PROCESS_INFORMATION pi = new PROCESS_INFORMATION();
            // Look at https://msdn.microsoft.com/en-us/library/windows/desktop/ms684863(v=vs.85).aspx for more information about process creation flags
            private const int CREATE_SUSPENDED = 0x00000004;
            public bool CreateProcess(string filename)
            {
                STARTUPINFO si = new STARTUPINFO();
                // Create a Win32 process started suspended. pi will hold the handles to the process and main thread
                return CreateProcess(filename, null, IntPtr.Zero, IntPtr.Zero, false, CREATE_SUSPENDED, IntPtr.Zero, null, ref si, out pi);
            }
            public void Start()
            {
                // Start the process which is currently suspended by resuming the main thread
                ResumeThread(pi.hThread);
            }
            public void Dispose()
            {
                // Handles to the thread and process must be released when done so no memory leaks occur
                CloseHandle(pi.hThread);
                CloseHandle(pi.hProcess);
            }
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static private extern bool CreateProcess(string lpApplicationName, string lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes,
                                    bool bInheritHandles, uint dwCreationFlags, IntPtr lpEnvironment,
                                    string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);
            [DllImport("kernel32.dll", SetLastError = true)]
            static private extern uint ResumeThread(IntPtr hThread);
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool CloseHandle(IntPtr hObject);
        }
