    public class Comment
    {
        [StringLength(200, MinimumLength = 1)]
        readonly string _value;
        public Comment(string value)
        {
            this._value = value;
        }
        public static implicit operator string(Comment value)
        {
            return value.ToString();
        }
        public static implicit operator Comment(string value)
        {
            return new Comment(value);
        }
    }
