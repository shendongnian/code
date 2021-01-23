    public class SalesOrder
    {
        private readonly List<SalesOrderItem> _items = new List<SalesOrderItem>();
        public IEnumerable<SalesOrderItem> Items
        {
            get { return new ReadOnlyCollection<SalesOrderItem>(_items); }
        }
        public void AddItem(string product, decimal price)
        {
            OnAddItem(new SalesOrderItem(product, price));
        }
        public void OnAddItem(SalesOrderItem item)
        {
            _items.Add(item);
        }
    }
