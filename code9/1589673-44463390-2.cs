    private static object ReadUnbuffered(string f)
    {
        //Unbuffered read and write operations can only
        //be performed with blocks having a multiple
        //size of the hard drive sector size
        byte[] buffer = new byte[4096 * 10];
        const ulong FILE_FLAG_NO_BUFFERING = 0x20000000;
        using (FileStream fs = new FileStream(
            f,
            FileMode.Open,
            FileAccess.Read,
            FileShare.None,
            8,
            (FileOptions)FILE_FLAG_NO_BUFFERING))
        {
            return fs.Read(buffer, 0, buffer.Length);
        }
    }
