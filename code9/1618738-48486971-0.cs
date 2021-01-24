    private void MyExtract(string zipToUnpack, string unpackDirectory)
    {
        using (ZipFile zip1 = ZipFile.Read(zipToUnpack))
        {
              // here, we extract every entry, but we could extract conditionally
              // based on entry name, size, date, checkbox status, etc.  
             foreach (ZipEntry e in zip1)
             {
                e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
             }
         }
      }
