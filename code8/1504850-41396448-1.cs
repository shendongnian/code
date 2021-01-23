    class ItemListAdapter : BaseAdapter<Item>
    {
        Activity context;
        public List<Item> listItems { get; set; }
        public ItemListAdapter(Activity context, List<Item> Items) : base()
        {
            this.context = context;
            this.listItems = Items;
        }
        public override Item this[int position]
        {
            get
            {
                return this.listItems[position];
            }
        }
        public override int Count
        {
            get
            {
                return this.listItems.Count;
            }
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Item item = listItems[position];
            View view = convertView;
            if (convertView == null || !(convertView is LinearLayout))
                view = context.LayoutInflater.Inflate(Resource.Layout.Itemlayout, parent, false);
            TextView itemId = view.FindViewById(Resource.Id.textItemId) as TextView;
            TextView itemContent = view.FindViewById(Resource.Id.textItemContent) as TextView;
            itemId.SetText(item.Id, TextView.BufferType.Normal);
            itemContent.SetText(item.Content, TextView.BufferType.Normal);
            return view;
        }
    }
