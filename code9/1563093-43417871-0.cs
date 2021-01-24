    public void CopyFileContentToLog()
    {
         var document = ReadByLine();
         WriteToFile(document);
    }
    
    public IEnumerable<string> ReadByLine()
    {
         string line;
         using(StreamReader reader = File.OpenText(...))
              while ((line = reader.ReadLine()) != null)
                  yield return line;
    }
    
    public void WriteToFile(IEnumerable<string> contents)
    {
         using(StreamWriter writer = new StreamWriter(...))
         {
              foreach(var line in contents)
                  writer.WriteLine(line);
    
              writer.Flush();
         }
    }
