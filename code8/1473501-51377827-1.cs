    public class Repo
    {
        public interface IItem
        {
            int Id { get; }
            string MyProperty { get; }
        }
        private class Item
        {
            public int Id { get; }
            public string MyProperty { get; private set; }
            public bool TrySetMyProperty(string newValue)
            {
                if (!Equals(MyProperty, newValue) &&
                    IsPreconditionValid())
                {
                    MyProperty = newValue;
                    return true;
                }
                else
                {
                    return false;
                }
                IsPreconditionValid() => true;
            }
        }
        public event EventHandler<EventArgs> OnChanged;
        private readonly ConcurrentDictionary<int, Item> items = new ConcurrentDictionary<int, Item>();
        public IItem GetOrCreateItemById(int id)
        {
            bool changed = false;
            IItem result = items.GetOrAdd(int, CreateItem);
            if (changed)
            {
                OnChanged?.Invoke(this, EventArgs.Empty);
            }
            return result;
            IItem CreateItem(int key)
            {
                changed = true;
                return new Item() { Id = key };
            }
        }
        public bool TrySetItemMyProperty(int id, string newValue)
        {
            if (items.TryGet(id, out Item i))
            {
                if (i.TrySetMyProperty(newValue))
                {
                    OnChanged?.Invoke(this, EventArgs.Empty);
                    return true;
                }
            }
            return false;
        }
    }
