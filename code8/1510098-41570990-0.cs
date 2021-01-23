        public class Relation
    {
        public int From;
        public int To;
    }
    public class Table
    {
        public List<Relation> Relations { get; } = new List<Relation>();
        public Dictionary<int, Dictionary<int, int>> FromDic = new Dictionary<int, Dictionary<int, int>>();
        public void Add(int from, int to)
        {
            if (IndexOf(from, to) == -1)
            {
                int index = Relations.Count;
                Relations.Add(new Relation() { From = from, To = to });
                Dictionary<int, int> innerDic;
                if (!FromDic.TryGetValue(from, out innerDic))
                {
                    innerDic = new Dictionary<int, int>();
                    FromDic[from] = innerDic;
                }
                innerDic[to] = index;
            }
        }
        public int IndexOf(int from, int to)
        {
            Dictionary<int, int> toDic;
            int index;
            if (FromDic.TryGetValue(from, out toDic) && toDic.TryGetValue(to, out index))
                return index;
            return -1;
        }
        public IEnumerable<int> TosOf(int from)
        {
            Dictionary<int, int> innerDic;
            if (FromDic.TryGetValue(from, out innerDic)) return innerDic.Keys;
            return new List<int>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Table t = new Table();
            int N = 100000;
            DateTime t0 = DateTime.Now;
            for (int i = 0; i < N; i++) t.Add(r.Next(N), r.Next(N));
            DateTime t1 = DateTime.Now;
            Console.WriteLine($"Add speed = {(t1 - t0).TotalMilliseconds * 1000 / N}mks");
            for (int i = 0; i < N; i++)
            {
                if (t.IndexOf(r.Next(N), r.Next(N)) != -1)
                {
                    // do something
                }
            }
            DateTime t2 = DateTime.Now;
            Console.WriteLine($"IndexOf speed = {(t2 - t1).TotalMilliseconds * 1000 / N}mks");
            for (int i = 0; i < N; i++)
            {
                foreach (int j in t.TosOf(r.Next(N)))
                {
                    // do something
                }
            }
            DateTime t3 = DateTime.Now;
            Console.WriteLine($"TosOf speed = {(t3 - t2).TotalMilliseconds * 1000 / N}mks");
            Console.ReadKey();
        }
    }
