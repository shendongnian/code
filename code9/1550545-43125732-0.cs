    protected override void OnResume()
    {
        base.OnResume();
        Handler handler = new Handler();
        Action action = async delegate { await UpdateListView(); };
        handler.Post(action);
    }
    private async Task UpdateListView()
    {
        //Get data from internet with async methods here and update the ListView
    }
