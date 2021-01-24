    private event EventHandler LoadData = delegate { };
    
    protected override void OnCreate(Bundle bundle) {
        base.OnCreate(bundle);
        // Set our view from the "main" layout resource
        SetContentView (Resource.Layout.Main);
        InitViews();
        LoadData += onDataLoading; // subscribe to event
        LoadData(this, EventArgs.Empty); // raise event
    }
    //async void allowed on event handlers (actual event handler)
    //*OnCreate* is not an event handler. Just a based method.
    private async void onDataLoading(object sender, EventArgs e) {
        LoadData -= onDataLoading;
        await LoadDataAsync();
    }
    private void InitViews() {
        //...
    }
    private async Task LoadDataAsync() {
        var svc = new NewsService();
        var promContent = svc.syncLoadStrong();
        await BindView(promContent);
    }
    private async Task BindView(ArticleList list) {
        Log.Debug(TAG, "Binding MainActivity");
        ViewGroup scroller = FindViewById<ViewGroup>(Resource.Id.scroller);        
        if (list != null) {
            var tasks = new List<Task>();
            int i = 0;
            foreach (ArticleTeaser teaser in list) {
                var atv = new ArticleTeaserView(this, null);
                tasks.Add(atv.SetModel(teaser));
                scroller.AddView(atv);
            }
            await Task.WhenAll(tasks);
        }
    }
