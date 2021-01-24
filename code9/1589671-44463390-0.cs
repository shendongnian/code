    private static object ReadUnBuffered(string f)
    {
        byte[] buffer = new byte[4096 * 10];
        const ulong FILE_FLAG_NO_BUFFERING = 0x20000000;
        using (FileStream fs = new FileStream(
            f,
            FileMode.Open,
            FileAccess.Read,
            FileShare.None,
            8,
            (FileOptions)FILE_FLAG_NO_BUFFERING | FileOptions.Asynchronous))
        {
            return fs.Read(buffer, 0, buffer.Length);
        }
    }
