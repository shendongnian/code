    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        var item = items[position];
        View view = convertView;
        if (view == null) // no view to re-use, create new
            view = context.LayoutInflater.Inflate(Resource.Layout.CustomView, null);
        view.FindViewById<TextView>(Resource.Id.Text1).Text = item.Heading;
        view.FindViewById<TextView>(Resource.Id.Text2).Text = item.SubHeading;
        view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);
        if (position % 2 == 0)
        {
            view.FindViewById<RelativeLayout>(Resource.Id.listView_item_bg).SetBackgroundColor(Color.Pink);
        }
        else
        {
            view.FindViewById<RelativeLayout>(Resource.Id.listView_item_bg).SetBackgroundColor(Color.Blue);
        }
        return view;
    }
