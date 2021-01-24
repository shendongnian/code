    FileUpload1.PostedFile.InputStream.Seek(0, SeekOrigin.Begin);
    using (var binaryReader = new BinaryReader(FileUpload1.PostedFile.InputStream))
    {
        fileBytes = binaryReader.ReadBytes(FileUpload1.PostedFile.InputStream.Length);
    }
