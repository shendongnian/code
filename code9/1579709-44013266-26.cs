    class EvlToken
    {
        public enum TokenType { Name, Number, Single }
        public TokenType Type { get; set; }
        public string Str { get; set; }
        public int LineNo { get; set; }
    }
