    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        View view = convertView;
    
        // re-use an existing view, if one is available
        // otherwise create a new one
        if (view == null)
        {
            view = context.LayoutInflater.Inflate(Resource.Layout.Grid, parent, false);
            //find GridView from Grid.axml and set columns count to 2 (only ID and Nick)
            GridLayout tableView = view.FindViewById<GridLayout>(Resource.Id.gridLayout1);
            tableView.ColumnCount = 2;
    
            //Creating TextView to show ID, place position is 0 - first
            TextView textCaption = new TextView(view.Context);
            textCaption.SetText(list[position].ID.ToString(), TextView.BufferType.Normal);
            tableView.AddView(textCaption, 0);
    
            //Creating TextView to show ID, place position is 1 - second in a row of Grid
            textCaption = new TextView(view.Context);
            textCaption.SetText(list[position].Nick, TextView.BufferType.Normal);
            tableView.AddView(textCaption, 1);
        }
    
        return view;
    }
