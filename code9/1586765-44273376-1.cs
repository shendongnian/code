    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        //inflate or restore convertView
        if(this.myItems[position].selected == true)
        {
            convertView.SetBackgroundColor(Color.Green);
        }
        convertView.Click -= ChangeBackgroundColor;
        convertView.Click += ChangeBackgroundColor;
        // This is to avoid adding more than one EventHandler every time the View is shown in the ListView.
    }
    private void ChangeBackgroundColor(object sender, EventArgs e)
    {
        int position = this.recyclerView.GetChildAdapterPosition((View)sender);
        this.myItems[position].selected = true;
        ((View)sender).SetBackgroundColor(Color.Green);
    }
