    public class Comment
    {
        [StringLength(200, MinimumLength = 1)]
        private readonly string _value;
        public Comment(string value)
        {
            this._value = value;
        }
        public static implicit operator string(Comment s)
        {
            return s.ToString();
        }
        public static implicit operator Comment(string s)
        {
            return new Comment(s);
        }
    }
