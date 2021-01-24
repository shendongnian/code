    private void ItemsViewA_Filter(object sender, FilterEventArgs e)
    {
        e.Accepted = Include(e.Item as YourType);
    }
    private bool Include(YourType obj)
    {
        //your filtering logic...
        return true;
    }
    private void ItemsViewB_Filter(object sender, FilterEventArgs e)
    {
        var item = e.Item as YourType;
        e.Accepted = Include(item) && /* your additional filtering logic */;
    }
