    public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
    {
        Item item = this.myItems[position];
        ((ViewHolderItem)holder).Name.Text = item.Name;
        ((ViewHolderItem)holder).Picture.SetImageBitmap(item.Picture);
        // Unsubscribe and subscribe the method, to avoid setting multiple times.
        ((ViewHolderItem)holder).Item.Click -= Item_Click;
        ((ViewHolderItem)holder).Item.Click += Item_Click;
    }
    private void Item_Click(object sender, EventArgs e)
    {
        int position = this.recyclerView.GetChildAdapterPosition((View)sender);
        Item itemClicked = this.myItems[position];
        if(itemClicked.Name == "Nintendo"){
            Toast.MakeText(this.context, "Nintendo", ToastLength.Long).Show();
        }
    }
