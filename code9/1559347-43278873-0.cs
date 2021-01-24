    public abstract class Records
    {
        public string Type;
        public string Source;
        public int Value;
    
        protected Records(string type, string source, int value)
        {
            Type = type;
            Source = source;
            Value = value;
        }
    }
    
    public class DocumentRecords : Records
    {
        public DocumentRecords(string source, int value)
            : base(ContentTypesString.DocumentNew, source, value) // use here
        {
        }
    }
    
    public class HeadlinesRecords : Records
    {
        public HeadlinesRecords(string source, int value)
            : base(ContentTypesString.HeadlinesNew, source, value) // use here
        {
        }
    }
    
    public static class ContentTypesString
    {
        public static string DocumentNew { get { return "Document - New this Month"; } }
    
        public static string HeadlinesNew { get { return "Headlines - New this Month"; } }
    }
