    public class ItemsSource 
    {
        public IItemsSource Instance { get; private set;}
        public ItemsSource(Type type, params string[] listParams)
        {
            if (!typeof(IItemsSource).IsAssignableFrom(type))
                throw new ArgumentException($"IItemsSource is not assignable from {type.Name}.");
            Instance = type.CreateInstance<IItemsSource>(listParams);
        }
    }
    public class MyCustomItemsSource : IItemsSource
    {
        private List<string> _privateList;
        public MyCustomItemsSource(string[] list)
        {
            _privateList = list.ToList();
        }
    
        public ItemCollection GetValues()
        {
            // _privateList will start with a value of [abc, 123], as we passed on the constructor.
            _privateList.Add("test");    
            // now [abc, 123, test]
            return strings;
        }
    }
