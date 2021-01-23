    static class Program
    {
        private static void Main(string[] args)
        {
            var enumCollection = new List<StoreType> { StoreType.Children, StoreType.Farm };
            var repo = new StoreRepository();
            var enumFilter = LinqExpressionHelper.BuildEnumFilter(enumCollection);
            var result  = repo.GetStores().Where(enumFilter).ToList();
            foreach (var store in result)
                Console.WriteLine($"Name={store.Name}, Type={store.StoreType}");
            Console.ReadKey();
        }
    }
    public enum StoreType
    {
        Children = 1,
        Adult = 2,
        Farm = 3
    }
    public class StoreRepository
    {
        public IEnumerable<Store> GetStores()
        {
            return new List<Store>
            {
                new Store {Name = "NewYork", StoreType = StoreType.Adult},
                new Store {Name = "RioDeJaneiro", StoreType = StoreType.Farm},
                new Store {Name = "Budapest", StoreType = StoreType.Children}
            };
        }
    }
    public class Store
    {
        public string Name { get; set; }
        public StoreType StoreType { get; set; }
    }
    public static class LinqExpressionHelper
    {
        public static Func<Store, bool> BuildEnumFilter(IEnumerable<StoreType> storeTypes)
        {
            return store => storeTypes.Contains(store.StoreType);
        }
    }
