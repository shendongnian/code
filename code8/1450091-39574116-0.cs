    void Main()
    {
        var a = new Lol(null);
    }
    public class Lol
    {
        public Lol(string a, string b)
        {
            LolHelper(a, b);
        }
        public Lol(Tuple<string, string> k)
        {
            if(k != null)
                LolHelper(a, b);
        }
        private void LolHelper(string a, string b)
        {
            if(a == null || b == null)
            {
                throw new Exception();
            }
        }
    }
