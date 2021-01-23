    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    struct FILE_INFO_3 {
        public int fi3_id;
        public int fi3_permissions;
        public int fi3_num_locks;
        public string fi3_pathname;
        public string fi3_username;
    }
    
    static class NativeMethods {
        [DllImport("netapi32.dll", CharSet = CharSet.Unicode)]
        public extern static int NetFileEnum(
            string servername, 
            string basepath, 
            string username, 
            int level, 
            out IntPtr bufptr, 
            int prefmaxlen, 
            out int entriesread, 
            out int totalentries, 
            ref IntPtr resume_handle
        );
    
        [DllImport("netapi32.dll", CharSet = CharSet.Unicode)]
        public extern static int NetFileClose(string servername, int fileid);
        
        [DllImport("netapi32.dll")]
        public extern static int NetApiBufferFree(IntPtr buffer);
    }
