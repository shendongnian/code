    public class Budget
    {
        public string Name { get; set; }
    }
    public interface IRepository<T> where T : class, IEnumerable<Budget>, new()
    {
        T Budgets { get; }
    }
    public class Repository<T> : IRepository<T> where T : class, IEnumerable<Budget>, new() 
    {
        public T Budgets
        {
            get
            {
                Budget[] data = GetData();
                var c = typeof(T).GetConstructor(new [] {typeof(Budget[])});
                object o = c.Invoke(new object[] { data });
                return o as T;
            }
        }
        private Budget[] GetData()
        {
            var a = new Budget[2];
            a[0] = new Budget { Name = "Hello world!" };
            a[1] = new Budget { Name = "Goodbye world!" };
            return a;
        }
    }
    class Example
    {
        static public void TestList()
        {
            Repository<List<Budget>> r = new Repository<List<Budget>>();
            var list = r.Budgets;
            foreach (var b in list)
            {
                Console.WriteLine(String.Format("{0}", b.Name));
            }
        }
        static public void TestQueue()
        {
            Repository<ConcurrentQueue<Budget>> r = new Repository<ConcurrentQueue<Budget>>();
            var list = r.Budgets;
            foreach (var b in list)
            {
                Console.WriteLine(String.Format("{0}", b.Name));
            }
        }
    }
