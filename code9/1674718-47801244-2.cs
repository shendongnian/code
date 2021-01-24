    public class OneThroughTen : IEnumerable<int>
    {
        private static int bar = 0;
        public IEnumerator<int> GetEnumerator()
        {
            while (true)
            {
                yield return ++bar;
                if (bar == 10)
                    { yield break; }
            }
        }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> x = new OneThroughTen();
            foreach (int i in x)
                { Console.Write("{0} ", i); }
        }
    }
