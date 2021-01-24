    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    {
       
        var vh = new MovieViewHolder(InflateViewForHolder(parent, viewType, itemBindingContext))
        {
            Click = ItemClick
        };
        return vh;
    }
