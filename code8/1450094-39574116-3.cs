    public class Lol
    {
        public Lol(string a, string b)
        {
            LolHelper(a, b);
        }
        public Lol(Tuple<string, string> k)
        {
            (k!=null)
                ?LolHelper(k.Item1, k.Item2)
                :LolHelper(null, null);
        }
        private void LolHelper(string a, string b)
        {
            if(a == null || b == null)
            {
                throw new Exception();
            }
        }
    }
