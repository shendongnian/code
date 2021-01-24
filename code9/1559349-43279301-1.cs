        static void Main(string[] args)
        {
            var builder = new RecordBuilder()
                .RegisterBuilder("document", (source, value) => new Document(source, value))
                .RegisterBuilder("headlines", (source, value) => new Headlines(source, value));
            
            builder.Build("document", "source", 1);
        }
    public class RecordBuilder
    {
        public Records Build(string code, string source, int value)
        {
            Func<string, int, Records> buildAction;
            if (recordBuilders.TryGetValue(code, out buildAction))
            {
                return buildAction(source, value);
            }
            return null;
        }
        public RecordBuilder RegisterBuilder(string code, Func<string, int, Records> buildAction)
        {
            recordBuilders.Add(code, buildAction);
            return this;
        }
        private Dictionary<string, Func<string, int, Records>> recordBuilders = new Dictionary<string, Func<string, int, Records>> ();
    }
    public class Document : Records
    {
        public Document(string source, int value) : base(ContentTypesString.DocumentNew, source, value)
        {
        }
    }
    public class Headlines : Records
    {
        public Headlines(string source, int value) : base(ContentTypesString.HeadlinesNew, source, value)
        {
        }
    }
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
    public static class ContentTypesString
    {
        public static string DocumentNew { get { return "Document - New this Month"; } }
        public static string HeadlinesNew { get { return "Headlines - New this Month"; } }
    }
