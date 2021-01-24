    internal class FileBytesCounter
        : FileStream
    {
        private const FileOptions FileFlagNoBuffering = (FileOptions)0x20000000;
        private const int CopyBufferSize = 1024 * 1024;
        //private const int CopyBufferSize = 4 * 1024 * 16;
        public FileBytesCounter(string path, FileShare share = FileShare.Read)
            : base(path, FileMode.Open, FileAccess.Read, share, CopyBufferSize/*, FileFlagNoBuffering*/)
        {
        }
        public long[] GetByteCount()
        {
            var buffer = new byte[CopyBufferSize];
            var storedCnt = new long[256];
            int count;
            while ((count = Read(buffer, 0, CopyBufferSize)) > 0)
            {
                for(var i = 0; i < count; i++)  
                {
                    storedCnt[buffer[i]]++;
                }
            }
            return storedCnt;
        }
    }
