    public ListViewAdapter(Context context, List<string> items)
    {
        Items = items;
        _list = new List<LifeStylesListItem>();
        //Your are creating a copy of your Items
        foreach (var item in items)
        {
            _list.Add(new LifeStylesListItem(item));
        }
        Context = context;
    }
