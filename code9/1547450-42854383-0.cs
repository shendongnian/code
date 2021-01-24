    static IntPtr GetThreadStartAddress(IntPtr hProc, int threadId)
    {
        IntPtr hThread = IntPtr.Zero;
        GCHandle handle = default(GCHandle);
        try
        {
            hThread = OpenThread(ThreadAccess.QueryInformation, false, threadId);
            if (hThread == IntPtr.Zero)
            {
                throw new Win32Exception("OpenThread failed");
            }
            var threadAddress = new IntPtr[1];
            handle = GCHandle.Alloc(threadAddress, GCHandleType.Pinned);
            var result = NtQueryInformationThread(hThread, ThreadInfoClass.ThreadQuerySetWin32StartAddress, handle.AddrOfPinnedObject(), IntPtr.Size, IntPtr.Zero);
            if (result != 0)
            {
                throw new Win32Exception(string.Format("NtQueryInformationThread failed; NTSTATUS = {0:X8}", result));
            }
            DbgHelpNative.SymSetOptions(DbgHelpNative.Options.SYMOPT_UNDNAME | DbgHelpNative.Options.SYMOPT_DEFERRED_LOADS);
            if (!DbgHelpNative.SymInitialize(hProc, null, true))
            {
                throw new Win32Exception(string.Format("SymInitialize failed"));
            }
            DbgHelpNative.SYMBOL_INFO symbolInfo = new DbgHelpNative.SYMBOL_INFO();
            // Look at your DbgHelpNative.SYMBOL_INFO.Name definition, there should be a SizeConst.
            // Change the 1024 to the SizeConst
            // If using Unicode, change 1024 to 1024 * 2
            // In the end SizeOfStruct should be 88, both at 32 and 64 bits, both Ansi and Unicode
            symbolInfo.SizeOfStruct = (uint)Marshal.SizeOf(typeof(DbgHelpNative.SYMBOL_INFO)) - 1024;
            // Change the 1024 to the SizeConst (both for Ansi and Unicode)
            symbolInfo.MaxNameLen = 1024;
            ulong displacement;
            if (!DbgHelpNative.SymFromAddr(hProc, (ulong)threadAddress[0], out displacement, ref symbolInfo))
            {
                throw new Win32Exception("SymFromAddr failed");
            }
            Console.WriteLine("Success");
            return threadAddress[0];
        }
        finally
        {
            if (hThread != IntPtr.Zero)
            {
                CloseHandle(hThread);
            }
            if (handle.IsAllocated)
            {
                handle.Free();
            }
        }
    }
