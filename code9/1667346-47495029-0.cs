    public class Form2: Form
    {
        public event EventHandler<ItemChangedEventArgs> ItemChanged;
        protected virtual void FireItemChanged(object o, Action a)
        {
            var e = ItemChanged;
            e?.Invoke(this, new ItemChangedEventArgs(o, a));
        }
        private void AddItem(object o)
        {
            listBox1.Items.Add(o);
            FireItemChanged(o, Action.Added);
        }
        private void RemoveItem(object o)
        {
            listBox1.Items.Remove(o);
            FireItemChanged(o, Action.Removed);
        }
    }
    public class ItemChangedEventArgs: EventArgs
    {
        public object Item {get; private set;}
        public Action Action {get; private set;}
        public ItemChangedEventArgs(object item, Action action)
        {
            Item = item;
            Action = action;
        }
    }
    public enum Action
    {
        Added,
        Removed
    }
