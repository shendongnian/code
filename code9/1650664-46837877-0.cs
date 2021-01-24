    public interface IHasParent<TParent> where TParent : class
    {
        TParent Parent { get; }
        void OnParentChanging(TParent newParent);
    }
    public class ChildCollection<TParent, TChild> : Collection<TChild>
        where TChild : IHasParent<TParent>
        where TParent : class
    {
        readonly TParent parent;
        public ChildCollection(TParent parent)
        {
            this.parent = parent;
        }
        protected override void ClearItems()
        {
            foreach (var item in this)
            {
                if (item != null)
                    item.OnParentChanging(null);
            }
            base.ClearItems();
        }
        protected override void InsertItem(int index, TChild item)
        {
            if (item != null)
                item.OnParentChanging(parent);
            base.InsertItem(index, item);
        }
        protected override void RemoveItem(int index)
        {
            var item = this[index];
            if (item != null)
                item.OnParentChanging(null);
            base.RemoveItem(index);
        }
        protected override void SetItem(int index, TChild item)
        {
            var oldItem = this[index];
            if (oldItem != null)
                oldItem.OnParentChanging(null);
            if (item != null)
                item.OnParentChanging(parent);
            base.SetItem(index, item);
        }
    }
