    class RemoteFile {
        public RemoteFile(string serverName, int id, string path, string userName) {
            ServerName = serverName;
            Id = id;
            Path = path;
            UserName = userName;
        }
        public string ServerName { get; }
        public int Id { get; }
        public string Path { get; }
        public string UserName { get; }
        
        public void Close() {
            int result = NativeMethods.NetFileClose(ServerName, Id);
            if (result != 0) {
                // handle error decently, omitted for laziness
                throw new Exception($"Error: {result}");
            }
        }
    }
    
    IEnumerable<RemoteFile> EnumRemoteFiles(string serverName, string basePath = null) {
        int entriesRead;
        int totalEntries;
        IntPtr resumeHandle = IntPtr.Zero;
        IntPtr fileEntriesPtr = IntPtr.Zero;
        try {
            int result = NativeMethods.NetFileEnum(
                servername: serverName,
                basepath: basePath, 
                username: null, 
                level: 3, 
                bufptr: out fileEntriesPtr, 
                prefmaxlen: -1, 
                entriesread: out entriesRead, 
                totalentries: out totalEntries, 
                resume_handle: ref resumeHandle
            );
            if (result != 0) {
                // handle error decently, omitted for laziness
                throw new Exception($"Error: {result}");
            }
            for (int i = 0; i != entriesRead; ++i) {
                FILE_INFO_3 fileInfo = (FILE_INFO_3) Marshal.PtrToStructure(
                    fileEntriesPtr + i * Marshal.SizeOf(typeof(FILE_INFO_3)), 
                    typeof(FILE_INFO_3)
                );
                yield return new RemoteFile(
                    serverName, 
                    fileInfo.fi3_id, 
                    fileInfo.fi3_pathname, 
                    fileInfo.fi3_username
                );
            }
        } finally {
            if (fileEntriesPtr != IntPtr.Zero) {
                NativeMethods.NetApiBufferFree(fileEntriesPtr);
            }
        }
    }
