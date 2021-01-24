    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        View view = convertView; // re-use an existing view, if one is available
        if (view == null) // otherwise create a new one
            view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
        var tv = view.FindViewById<TextView>(Android.Resource.Id.Text1);
        tv.Text = items[position];
        return view;
    }
