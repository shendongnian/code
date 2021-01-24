    public class ParseException : Exception
    {
        public ParseException(string message) : base(message) { }
    }
    public class Analyzer
    {
        protected int position;
        protected string input;
        protected Dictionary<char, bool> predicates;
        public Analyzer(string input)
        {
            this.input = input;
        }
        public bool? Evaluate(Dictionary<char, bool> predicates = null)
        {
            position = 0;
            this.predicates = predicates;
            try
            {
                bool value = T();
                if (position == input.Length)
                {
                    return value;
                }
            }
            catch (ParseException)
            {
            }
            return null;
        }
        protected char GetChar()
        {
            if (position >= input.Length)
            {
                throw new ParseException("Unexpected end of input");
            }
            return input[position++];
        }
        protected void MatchChar(char c)
        {
            if (GetChar() != c)
            {
                throw new ParseException("Invalid input");
            }
        }
        protected bool T()
        {
            char c = GetChar();
            if (c == '~')
            {
                MatchChar('(');
                bool val = T();
                MatchChar(')');
                return !val;
            }
            if (c == '>')
            {
                MatchChar('(');
                bool val1 = T();
                MatchChar(',');
                bool val2 = T();
                MatchChar(')');
                return val2 || !val1;
            }
            if (c == '=')
            {
                MatchChar('(');
                bool val1 = T();
                MatchChar(',');
                bool val2 = T();
                MatchChar(')');
                return val1 == val2;
            }
            if (c == '&')
            {
                MatchChar('(');
                bool val1 = T();
                MatchChar(',');
                bool val2 = T();
                MatchChar(')');
                return val1 && val2;
            }
            if (c == '|')
            {
                MatchChar('(');
                bool val1 = T();
                MatchChar(',');
                bool val2 = T();
                MatchChar(')');
                return val1 || val2;
            }
            if (c == '0')
            {
                return false;
            }
            if (c == '1')
            {
                return true;
            }
            if (c >= 'A' && c <= 'Z')
            {                   
                if (predicates == null) { return false; }
                if (predicates.TryGetValue(c, out bool val))
                {
                    return val;
                }
                throw new ParseException("Predicate value not found");
            }
            throw new ParseException("Invalid input");
        }
    }
