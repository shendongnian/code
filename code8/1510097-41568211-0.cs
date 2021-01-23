    public class Table
    {
        public Dictionary<int, HashSet<int>> froms { get; } = new Dictionary<int, HashSet<int>>();
        public Dictionary<int, HashSet<int>> tos { get; } = new Dictionary<int, HashSet<int>>();
        public void Add(int from, int to)
        {
            if (!Contains(from, to))
            {
                if (!froms.ContainsKey(from))
                {
                    froms.Add(from, new HashSet<int> { to });
                }
                else
                {
                    froms[from].Add(to);
                }
                if (!tos.ContainsKey(to))
                {
                    tos.Add(to, new HashSet<int> { from });
                }
                else
                {
                    tos[to].Add(from);
                }
            }
        }
        public bool Contains(int from, int to)
        {
            if (!froms.ContainsKey(from))
                return false;
            if (!froms[from].Contains(to))
                return false;
            return true;
        }
        public IEnumerable<int> FromsOf(int to)
        {
            if(tos.ContainsKey(to))
                return tos[to];
            else
                return new List<int>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Table t = new Table();
            int N = 1000000;
            for (int i = 0; i < N; i++)
                t.Add(r.Next(N), r.Next(N));
            DateTime t1 = DateTime.Now;
            for (int i = 0; i < N; i++)
            {
                if (t.Contains(r.Next(N), r.Next(N)))
                {
                    // do something
                }
            }
            DateTime t2 = DateTime.Now;
            for (int i = 0; i < N; i++)
            {
                foreach (int j in t.FromsOf(r.Next(N)))
                {
                    // do something
                }
            }
            DateTime t3 = DateTime.Now;
            Console.WriteLine($"IndexOf speed = {(t2 - t1).TotalMilliseconds / N}ms");
            Console.WriteLine($"FromsOf speed = {(t3 - t2).TotalMilliseconds / N}ms");
            Console.ReadKey();
        }
    }
