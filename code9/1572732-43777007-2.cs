    public class DownloadsAdapter : BaseAdapter<string>
    {
        private List<string> items = new List<string>();
        private Activity context;
    
        public DownloadsAdapter(Activity context, List<string> items) : base()
        {
            this.context = context;
            this.items = items;
        }
    
        public override string this[int position]
        {
            get { return items[position]; }
        }
    
        public override int Count
        {
            get { return items.Count; }
        }
    
        public override long GetItemId(int position)
        {
            return position;
        }
    
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null)
            { // otherwise create a new one
                view = context.LayoutInflater.Inflate(Resource.Layout.downloadscell, null);
            }
            var pbar = view.FindViewById<ProgressBar>(Resource.Id.progressbar);
    
            var tv = view.FindViewById<TextView>(Resource.Id.tv);
            tv.Text = items[position];
    
            return view;
        }
    }
