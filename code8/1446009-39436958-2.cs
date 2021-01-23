    class Sentence
    {
        public string Text { get; set; }
        public Token[] Tokens { get; set; }
    }
    class Token
    {
        public string Text { get; set; }
        public string[] Tags { get; set; }
    }
