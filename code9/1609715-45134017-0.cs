    public class CsvFileReader : StreamReader
    {
      public CsvFileReader(Stream stream)
        : base(stream)
      {
      }
    
      public CsvFileReader(string filename)
         : base(MemoryStream(File.ReadAllBytes(filename)))
      {
      }
    ...
    }
