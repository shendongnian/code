    public abstract class DataSeed {
    
      protected Context _context { get; set; }
    
      protected IReadOnlyList<String> _languages  { get; private set; } = new List<String> { "en", "fr" }.AsReadOnly();
    
      protected const String DRIVE = "http://mydriveurl";
    
    }
