    public ScrapGroupsListView()
    {
        this.CheckBoxes = true;
        this.HeaderStyle = ColumnHeaderStyle.None;
        this.View = View.List;
    }
    public void Fill()
    {
        this.Items.Clear();
        foreach( var value in Enum.GetValues( typeof( ScrapGroup ) ).Cast<ScrapGroup>() )
        {
            this.Items.Add( new ListViewItem()
            {
                Name = value.ToString(),
                Text = value.ToString(),
                Tag = value,
            } );
        }
    }
