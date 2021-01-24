    public class Token
    {
        public int Id { get; set; }
        public override string ToString()
        {
            return $"token{Id}";
        }
    }
    public class Friend
    {
        public int Id { get; set; }
        public List<Token> Tokens { get; set; }
        public override string ToString()
        {
            return $"friend{Id}";
        }
    }
