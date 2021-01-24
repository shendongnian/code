    long offset = 1024 * 1024;
    const string remotePath = "/remote/path";
    // Quickly create an dummy temporary local file with the desired size
    string localPath = Path.GetTempFileName();
    using (FileStream fs = File.Create(localPath))
    {
        fs.Seek(offset, SeekOrigin.Begin);
        fs.WriteByte(0);
    }
    // "Resume" the download
    TransferOptions transferOptions = new TransferOptions();
    transferOptions.OverwriteMode = OverwriteMode.Resume;
    session.GetFiles(
        session.EscapeFileMask(remotePath), localPath, false, transferOptions).Check();
    // Read the downloaded chunk 
    byte[] chunk;
    using (FileStream fs = File.OpenRead(localPath))
    {
        fs.Seek(offset, SeekOrigin.Begin);
        int downloaded = (int)(fs.Length - offset);
        chunk = new byte[downloaded];
        fs.Read(chunk, 0, downloaded);
    }
    // Delete the temporary file
    File.Delete(localPath);
