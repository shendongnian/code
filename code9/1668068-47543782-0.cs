    public class ListHandler 
    {
        private readonly List<IStackable> list;
        public ListHandler()
        {
            list = new List<IStackable>();
        }
        public void Register(IStackable item)
        {
            list.Add(item);
        }
    }
    public class BaseClass<T> : BaseClass, IStackable where T : BaseParamClass
    {
        public T Param { get; private set; }
        public BaseClass(ListHandler listHandler)
            : base(listHandler)
        {
            listHandler.Register(this);
        }
    }
