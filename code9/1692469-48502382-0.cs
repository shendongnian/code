    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    struct LV_COLUMN
    {
        public System.Int32 mask;
        public System.Int32 fmt;
        public System.Int32 cx;
        public System.IntPtr pszText;
        public System.Int32 cchTextMax;
        public System.Int32 iSubItem;
        public System.Int32 iImage;
        public System.Int32 iOrder;
    }
        public static string GetListViewColumn(System.IntPtr hwnd, uint processId, int Column)
        {
            const int dwBufferSize = 2048;
            const int LVM_FIRST = 0x1000;
            const int LVM_GETCOLUMNA = LVM_FIRST + 25;
            const int LVM_GETCOLUMNW = LVM_FIRST + 95;
            const int LVCF_FMT = 0x00000001;
            const int LVCF_TEXT = 0x00000004;
            int bytesWrittenOrRead = 0;
            LV_COLUMN lvCol;
            string retval;
            bool bSuccess;
            System.IntPtr hProcess = System.IntPtr.Zero;
            System.IntPtr lpRemoteBuffer = System.IntPtr.Zero;
            System.IntPtr lpLocalBuffer = System.IntPtr.Zero;
            try
            {
                lvCol = new LV_COLUMN();
                lpLocalBuffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(dwBufferSize);
                hProcess = OpenProcess(Win32ProcessAccessType.AllAccess, false, processId);
                if (hProcess == System.IntPtr.Zero)
                    throw new System.ApplicationException("Failed to access process!");
                lpRemoteBuffer = VirtualAllocEx(hProcess, System.IntPtr.Zero, dwBufferSize, Win32AllocationTypes.MEM_COMMIT, Win32MemoryProtection.PAGE_READWRITE);
                if (lpRemoteBuffer == System.IntPtr.Zero)
                    throw new System.SystemException("Failed to allocate memory in remote process");
                lvCol.mask = LVCF_TEXT;
                lvCol.pszText = (System.IntPtr)(lpRemoteBuffer.ToInt32() + System.Runtime.InteropServices.Marshal.SizeOf(typeof(LV_COLUMN)));
                lvCol.cchTextMax = 500;
                lvCol.iOrder = Column;
                lvCol.iSubItem = Column;
                bSuccess = WriteProcessMemoryGETCOLUMN(hProcess, lpRemoteBuffer, ref lvCol, (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(LV_COLUMN)), out bytesWrittenOrRead);
                if (!bSuccess)
                    throw new System.SystemException("Failed to write to process memory");
                SendMessage(hwnd, LVM_GETCOLUMNW, (System.IntPtr)Column, lpRemoteBuffer);
                bSuccess = ReadProcessMemory(hProcess, lpRemoteBuffer, lpLocalBuffer, dwBufferSize, out bytesWrittenOrRead);
                if (!bSuccess)
                    throw new System.SystemException("Failed to read from process memory");
                retval = System.Runtime.InteropServices.Marshal.PtrToStringUni((System.IntPtr)(lpLocalBuffer.ToInt32() + System.Runtime.InteropServices.Marshal.SizeOf(typeof(LV_COLUMN))));
            }
            finally
            {
                if (lpLocalBuffer != System.IntPtr.Zero)
                    System.Runtime.InteropServices.Marshal.FreeHGlobal(lpLocalBuffer);
                if (lpRemoteBuffer != System.IntPtr.Zero)
                    VirtualFreeEx(hProcess, lpRemoteBuffer, 0, Win32AllocationTypes.MEM_RELEASE);
                if (hProcess != System.IntPtr.Zero)
                    CloseHandle(hProcess);
            }
            return retval;
        }
