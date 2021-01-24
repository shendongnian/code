    public override bool OnCreateOptionsMenu(IMenu menu)
    {
            MenuInflater.Inflate(Resource.Menu.main_menu, menu);
            menu.Add(0, 99, 0, "DB Copy to SDCard (Debug)");
            return base.OnPrepareOptionsMenu(menu);
    }
