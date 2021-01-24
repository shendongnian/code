    protected override void OnAppearing()
    {
    	base.OnAppearing();
     	GoToMaster();    			
    }
    
    private async void GoToMaster()
    {
    	await Task.Delay(5000);
    	await this.Navigation.PushAsync(new SignUpPage());
    }
