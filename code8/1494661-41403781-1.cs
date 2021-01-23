    // Custom Analyzer implementing UrlTokenizer and LowerCaseFilter.
    public sealed class UrlAnalyzer : Analyzer
    {
        public override TokenStream TokenStream(System.String fieldName, System.IO.TextReader reader)
        {
            //
            // This is where all the magic happens for UrlAnalyzer!
            // UrlTokenizer token text are filtered to lowercase text.
            return new LowerCaseFilter(new UrlTokenizer(reader));
        }
        public override TokenStream ReusableTokenStream(System.String fieldName, System.IO.TextReader reader)
        {
            Tokenizer tokenizer = (Tokenizer)PreviousTokenStream;
            if (tokenizer == null)
            {
                tokenizer = new UrlTokenizer(reader);
                PreviousTokenStream = tokenizer;
            }
            else
                tokenizer.Reset(reader);
            return tokenizer;
        }
    }
