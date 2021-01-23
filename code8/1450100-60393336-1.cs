    public class Lol
    {
        public Lol(string a, string b)
        {
            if(a == null || b == null)
            {
                throw new ArgumentNullException();
            }
        }
    
        public Lol(Tuple<string, string> k)
            : this(k.NotNull(nameof(k)).Item1, k.NotNull(nameof(k)).Item2)
        {
        }
    }
