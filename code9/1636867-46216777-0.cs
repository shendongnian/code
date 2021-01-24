    protected override void OnAppearing() {
        this.Appearing += Page_Appearing; //Subscribe to event
        base.OnAppearing();
    }
    
    protected async void Page_Appearing(object sender, EventArgs args) {
        if(App.Database != null) {
            Infolistview.ItemsSource = await App.Database.GetInfoesAsync();
        }
        //this.Appearing -= Page_Appearing; //Unsubscribe (OPTIONAL but advised)
    }
