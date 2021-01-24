    public class Model
    {
        // is non-null in any Model instance
        public IReadOnlyList<ModelItem> Items { get; }
    
        public Model(IEnumerable<ModelItem> items)
        {
            Items = new List<ModelItems>(items); // does not check if items contains null
        }
    }
