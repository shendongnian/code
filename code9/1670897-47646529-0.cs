    protected override async void OnAppearing()
        {
          base.OnAppearing();
    
          await Task.Delay(2000);
    
          await Task.WhenAll(
            SplashGrid.FadeTo(0, 500),
            Logo.ScaleTo(0, 250)
            );
          SplashGrid.IsVisible = false;
        } 
