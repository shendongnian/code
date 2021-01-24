    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    {
       
        var vh = new MovieViewHolder(...)
        {
            Click = ItemClick
        };
        return vh;
    }
