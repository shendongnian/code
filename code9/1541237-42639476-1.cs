    public override void OnViewCreated (View view, Bundle savedInstanceState)
    {
        base.OnViewCreated (view, savedInstanceState);
        listView.Adapter = new CustomAdapter (Activity, serialNumbers);
    }
