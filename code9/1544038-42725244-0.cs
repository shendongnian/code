    public class CartItems : Collection<CartItem>
    {
        public CartItems() : base() { }
        public CartItems(CartItem parent) : this()
        {
            this.Parent = parent;
        }
        public CartItem Parent { get; private set; }
        protected override void RemoveItem(int index)
        {
            CartItem oldItem = null;
            if (index >= 0 && index < Count)
            {
                oldItem = this[index];
            }
            base.RemoveItem(index);
        }
        protected override void InsertItem(int index, CartItem item)
        {
            base.InsertItem(index, item);
            if (item != null)
                item.Parent = this;
        }
        protected override void SetItem(int index, CartItem item)
        {
            CartItem oldItem = null;
            if (index >= 0 && index < Count)
            {
                oldItem = this[index];
            }
            base.SetItem(index, item);
            if (oldItem != null)
                oldItem.Parent = null;
            if (item != null)
                item.Parent = this;
        }
        protected override void ClearItems()
        {
            foreach (var item in this)
                if (item != null)
                    item.Parent = null;
            base.ClearItems();
        }
    }
    public class CartItem
    {
        public CartItem()
        {
            this.Children = new CartItems(this);
        }
        public int t { get; set; }
        public int i { get; set; }
        public int n { get; set; }
        public bool r { get; set; }
        
        [JsonProperty("c")]
        public CartItems Children { get; private set; }
        [JsonIgnore]
        public CartItems Parent { get; set; }
    }
