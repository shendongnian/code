    // UrlTokenizer delimits tokens by whitespace, '.' and '/'
    using AttributeSource = Lucene.Net.Util.AttributeSource;  
    public class UrlTokenizer : CharTokenizer
    {
        public UrlTokenizer(System.IO.TextReader @in)
            : base(@in)
        {
        }
        public UrlTokenizer(AttributeSource source, System.IO.TextReader @in)
            : base(source, @in)
        {
        }
    
        public UrlTokenizer(AttributeFactory factory, System.IO.TextReader @in)
            : base(factory, @in)
        {
        }
        //
        // This is where all the magic happens for our UrlTokenizer!
        // Whitespace, forward slash or a period are a token boundary.
        // 
        protected override bool IsTokenChar(char c)
        {
            return !char.IsWhiteSpace(c) && c != '/' && c != '.';
        }
    }
