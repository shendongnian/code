    public class SpinnerAdapter : BaseAdapter<String>
    {
        Context context;
        List<String> list;
        public SpinnerAdapter(Context c, List<String> list)
        {
            context = c;
            this.list = list;
        }
        public override string this[int position] => list[position-1];
        public override int Count => this.list.Count+1;
        public override long GetItemId(int position)
        {
            return 0;
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view;
            if (position == 0)
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.spinner_error,null);
                var txtView = view.FindViewById<TextView>(Resource.Id.tvErr);
                view.FindViewById<TextView>(Resource.Id.tvErr).Text = "None Selected";
                //uncomment the following line if you want to show the error icon inside of spinner
                //view.FindViewById<TextView>(Resource.Id.tvErr).Error = "";
            }
            else
            {
                view = convertView;
                if (view == null|| view.FindViewById<TextView>(Resource.Id.tvItem)==null)
                {
                    view = LayoutInflater.From(context).Inflate(Resource.Layout.spinner_item, null);
                }
                view.FindViewById<TextView>(Resource.Id.tvItem).Text = list[position-1];
                
            }
            return view;
        }
    }
