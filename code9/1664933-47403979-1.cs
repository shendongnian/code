        /*Part1: preparation for using Win32 apis*/
        const uint GENERIC_WRITE = 0x40000000;
        const uint CREATE_ALWAYS = 2;
        System.IntPtr handle;
        [System.Runtime.InteropServices.DllImport("kernel32", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        static extern unsafe System.IntPtr CreateFile
        (
            string FileName,          // file name
            uint DesiredAccess,       // access mode
            uint ShareMode,           // share mode
            uint SecurityAttributes,  // Security Attributes
            uint CreationDisposition, // how to create
            uint FlagsAndAttributes,  // file attributes
            int hTemplateFile         // handle to template file
        );
        [System.Runtime.InteropServices.DllImport("kernel32", SetLastError = true)]
        static extern unsafe bool WriteFile
        (
            System.IntPtr hFile,      // handle to file
            void* pBuffer,            // data buffer
            int NumberOfBytesToWrite,  // number of bytes to write
            int* pNumberOfBytesWirtten,  // number of bytes written
            int Overlapped            // overlapped buffer
        );
        [System.Runtime.InteropServices.DllImport("kernel32", SetLastError = true)]
        static extern unsafe bool CloseHandle
        (
            System.IntPtr hObject // handle to object
        );
        public bool Open(string FileName)
        {
            // open the existing file for reading       
            handle = CreateFile
            (
                FileName,
                GENERIC_WRITE,
                0,
                0,
                CREATE_ALWAYS,
                0,
                0
            );
            if (handle != System.IntPtr.Zero)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public unsafe int Write(byte[] buffer, int index, int count)
        {
            int n = 0;
            fixed (byte* p = buffer)
            {
                if (!WriteFile(handle, p + index, count, &n, 0))
                {
                    return 0;
                }
            }
            return n;
        }
        public bool Close()
        {
            return CloseHandle(handle);
        }
        /*End Part1*/
        /*Part2: Test writing */
        private void WriteFile()
        {
            string curFile = @"U:\mytest\testfile.txt";
            string teststr = "Wirte here for testing";
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(teststr);
            if (Open(curFile))
            {
                int bytesWrite;
                bytesWrite = Write(buffer, 0, buffer.Length);
                System.Diagnostics.Debug.WriteLine("Write bytes count:{0}", bytesWrite);
                Close();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Failed to open requested file");
            }
        }
        /*End Part2*/
