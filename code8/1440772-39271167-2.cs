    public void OnItemTapped(object sender, ItemTappedEventArgs args)
    {
        var itm = args.Item as Pick;
        itm.IsSelected = !itm.IsSelected;
    }
