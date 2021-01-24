    public class MainAdapter : BaseAdapter<string>
    {
        private string[] items;
        private Activity context;
    
        public MainAdapter(Activity context, string[] items) : base()
        {
            this.context = context;
            this.items = items;
        }
    
        public override string this[int position]
        {
            get
            {
                return items[position];
            }
        }
    
        public override int Count
        {
            get
            {
                return items.Length;
            }
        }
    
        public override long GetItemId(int position)
        {
            return position;
        }
    
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = items[position].ToString();
            return view;
        }
    }
