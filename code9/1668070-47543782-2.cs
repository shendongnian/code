    public class ListHandler 
    {
        private readonly Dictionary<string, IStackable> list;
        public ListHandler()
        {
            list = new Dictionary<string, IStackable>();
        }
        public void Register(IStackable item)
        {
            list.Add(item.Title, item);
        }
    }
    public class BaseClass<T> : IStackable where T : BaseParamClass
    {
        private ListHandler listHandler;
        public T Param { get; private set; }
        public BaseClass(ListHandler listHandler)
        {
            this.listHandler = listHandler;
            listHandler.Register(this);
        }
        public string Title { get; set; }
    }
