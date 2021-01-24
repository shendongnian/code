    public void WriteFile(string targetDirectory, string targetFilePath, Stream fileStream)
    {
      var options = SetOptions();
      var newFile = GetTargetCloudFile(targetDirectory, targetFilePath);
      const int bufferLength= 600;
      byte[] buffer = new byte[bufferLength];
      // Buffer to read from stram This size is just an example
   
      List<byte> byteArrayFile = new List<byte>(); // all your file will be here
      int count = 0;
   
      try
      {
          while ((count = fileStream.Read(buffer, 0, bufferLength)) > 0)
             {
                byteArrayFile.AddRange(buffer);               
             }                    
             fileStream.Close();
       }
       catch (Exception ex)
       {
           throw; // you need to change this
       }
                
       file.UploadFromByteArray(allFile.ToArray(), 0, byteArrayFile.Count);
       // Not sure about byteArrayFile.Count.. it should work
    }
