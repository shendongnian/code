    public MovieViewHolder(View itemView, ...) : base(itemView)
    {
        ItemView.Click += OnItemClick;
    }
    
    private void OnItemClick(object s, EventArgs e)
    {
    }
    
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            ItemView.Click -= OnItemClick;
        }
    }
