    var kernel = session.Source.Kernel;
    kernel.FileIORead += HandleFileIoReadWrite;
    kernel.FileIOWrite += HandleFileIoReadWrite;
    private void HandleFileIoReadWrite(FileIOReadWriteTraceData data)
    {
        if (data.ProcessID == pid) // (data.ProcessName.Contains("foo"))
        {
                Console.WriteLine(data.FileName);
        }
    }
