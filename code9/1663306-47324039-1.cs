    Stream serviceResult = documentReaderMock.GetDocument("abc");
    using (FileStream fileStream = File.Create(_sourceFilePath + "\\DownloadedFile.pdf",(int)serviceResult.Length))
    {
      BinaryWriter bw = new BinaryWriter(fileStream);
      byte[] bytesInStream = new byte[serviceResult.Length];
      serviceResult.Read(bytesInStream, 0, bytesInStream.Length);
      bw.Write(bytesInStream);
      bw.Close();
    }
