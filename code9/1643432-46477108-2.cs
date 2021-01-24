    public interface IItemsSource
    {
        List<string> GetValues();
    }
    class ItemsSourceAttribute : Attribute
    {
        public IItemsSource Instance { get; set; }
        public ItemsSourceAttribute(Type type, params string[] listParams)
        {
            if (!typeof(IItemsSource).IsAssignableFrom(type))
                throw new ArgumentException($"IItemsSource is not assignable from {type.Name}.");
            Instance = (IItemsSource) Activator.CreateInstance(type, listParams);
        }
    }
    public class MyCustomItemsSource : IItemsSource
    {
        private List<string> _privateList;
        public MyCustomItemsSource(params string[] list)
        {
            _privateList = list.ToList();
        }
        public List<string> GetValues()
        {
            // _privateList will start with a value of [abc, 123], as we passed on the constructor.
            _privateList.Add("test");
            // now [abc, 123, test]
            return _privateList;
        }
    }
