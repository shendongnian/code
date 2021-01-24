     public static class ProcessExtensions
        {
            #region Methods
    
            public static void Suspend(this Process process)
            {
                Action<ProcessThread> suspend = pt =>
                {
                    var threadHandle = NativeMethods.OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pt.Id);
    
                    if (threadHandle != IntPtr.Zero)
                    {
                        try
                        {
                            NativeMethods.SuspendThread(threadHandle);
                        }
                        finally
                        {
                            NativeMethods.CloseHandle(threadHandle);
                        }
                    };
                };
    
                var threads = process.Threads.ToArray<ProcessThread>();
    
                if (threads.Length > 1)
                {
                    Parallel.ForEach(threads, new ParallelOptions { MaxDegreeOfParallelism = threads.Length }, pt =>
                    {
                        suspend(pt);
                    });
                }
                else
                {
                    suspend(threads[0]);
                }
            }
    
            public static void Resume(this Process process)
            {
                Action<ProcessThread> resume = pt =>
                {
                    var threadHandle = NativeMethods.OpenThread(ThreadAccess.SUSPEND_RESUME, false, (uint)pt.Id);
    
                    if (threadHandle != IntPtr.Zero)
                    {
                        try
                        {
                            NativeMethods.ResumeThread(threadHandle);
                        }
                        finally
                        {
                            NativeMethods.CloseHandle(threadHandle);
                        }
                    }
                };
    
                var threads = process.Threads.ToArray<ProcessThread>();
    
                if (threads.Length > 1)
                {
                    Parallel.ForEach(threads, new ParallelOptions { MaxDegreeOfParallelism = threads.Length }, pt =>
                    {
                        resume(pt);
                    });
                }
                else
                {
                    resume(threads[0]);
                }
            }
    
            #endregion
    
            #region Interop
    
            static class NativeMethods
            {
                [DllImport("kernel32.dll")]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool CloseHandle(IntPtr hObject);
    
                [DllImport("kernel32.dll")]
                public static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
    
                [DllImport("kernel32.dll")]
                public static extern uint SuspendThread(IntPtr hThread);
    
                [DllImport("kernel32.dll")]
                public static extern uint ResumeThread(IntPtr hThread);
            }
    
            [Flags]
            enum ThreadAccess : int
            {
                TERMINATE = (0x0001),
                SUSPEND_RESUME = (0x0002),
                GET_CONTEXT = (0x0008),
                SET_CONTEXT = (0x0010),
                SET_INFORMATION = (0x0020),
                QUERY_INFORMATION = (0x0040),
                SET_THREAD_TOKEN = (0x0080),
                IMPERSONATE = (0x0100),
                DIRECT_IMPERSONATION = (0x0200)
            }
    
            #endregion
        }
