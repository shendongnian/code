    protected override void OnAppearing() {
        this.Appearing += Page_Appearing; //Subscribe to event
        base.OnAppearing();
    }
    
    protected async void Page_Appearing(object sender, EventArgs args) {
        listView.ItemsSource = await GetFootmarks(); //get data asynchronously
        //this.Appearing -= Page_Appearing; //Unsubscribe (OPTIONAL but advised)
    }
    
    protected async void Handle_Refreshing(object sender, System.EventArgs e) {
        listView.ItemsSource = await GetFootmarks(); //get data asynchronously
        listView.EndRefresh();
    }
