    public class Lol
    {
        public Lol(string a, string b)
        {
            if(a == null || b == null)
            {
                throw new Exception();
            }
        }
        public Lol(Tuple<string, string> k)
        : this(k != null ? k.Item1 : null, k != null ? k.Item2 : null)
        {
        }
    }
