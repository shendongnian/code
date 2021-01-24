    public class GridViewAdapter : BaseAdapter<FoodTable>
    {
        private MainActivity mContext;
        private List<FoodTable> tvShows;
        public GridViewAdapter(MainActivity context, List<FoodTable> tvShows)
        {
            this.mContext = context;
            this.tvShows = tvShows;
        }
        public override FoodTable this[int position]
        {
            get { return tvShows[position]; }
        }
        public override int Count => tvShows.Count;
        public override long GetItemId(int position)
        {
            return position;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            FoodTable item = tvShows[position];
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) 
                view = mContext.LayoutInflater.Inflate(Resource.Layout.item, null);
            view.FindViewById<TextView>(Resource.Id.Shenase).Text = item.Types;
            view.FindViewById<TextView>(Resource.Id.Types).Text = item.Types;
            view.FindViewById<TextView>(Resource.Id.Names).Text = item.Names;
            view.FindViewById<TextView>(Resource.Id.Costs).Text = item.Costs;
            return view;
        }
    }  
