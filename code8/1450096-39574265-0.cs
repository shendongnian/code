    void Main()
    {
        var a = new Lol(null);
    }
    public class Lol
    {
        public Lol(string a, string b)
        {
            if(a == null || b == null)
                throw new Exception();
        }
        public Lol(Tuple<string, string> k)
            : this(k?.Item1, k?.Item2)
        {
        }
    }
