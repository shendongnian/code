    public class EnglishMonarchAdapter : BaseAdapter<EnglishMonarch>
    {
        public List<EnglishMonarch> Items { get; set;}
        private readonly Context context;
        public EnglishMonarchAdapter (Context context, List<EnglishMonarch> items)
        {
            this.context = context;
            Items = items ?? new List<EnglishMonarch> ();
        }
        public override EnglishMonarch this [int position]
        {
            get { return Items [position]; }
        }
        public override int Count
        {
            get { return Items.Count; }
        }
        public override long GetItemId (int position)
        {
            return position;
        }
        public override View GetView (int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? LayoutInflater.FromContext (context).Inflate (Resource.Layout.englishmonarch_item_layout, parent, false);
            var item = Items [position];
            var tvName = view.FindViewById<TextView> (Resource.Id.tvName);
            var tvHouse = view.FindViewById<TextView> (Resource.Id.tvHouse);
            var tvYear = view.FindViewById<TextView> (Resource.Id.tvYears);
            var tvCity = view.FindViewById<TextView> (Resource.Id.tvCity);
            tvName.Text = item.Name;
            tvHouse.Text = item.House;
            tvYear.Text = item.Years;
            tvCity.Text = item.City;
            return view;
        }
    }
