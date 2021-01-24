     using (ZipFile zip = ZipFile.Read(currentFile.FullName))
     {
                ZipEntry e = zip[this.searchFile.Text];
    
                using (MemoryStream reader = new MemoryStream())
                {
                    e.Extract(reader);
                    reader.Position = 0;
                    var stringReader = new StreamReader(reader);
                    var stringOfStream = stringReader.ReadToEnd();
                }
    
      }
