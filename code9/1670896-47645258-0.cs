    protected override async void OnAppearing()
    {
      base.OnAppearing();
      await Task.Delay(2000);
      await Task.WhenAll(
        SplashGrid.FadeTo(0, 2000),
        Logo.ScaleTo(0, 250)
        );
      SplashGrid.Visibility = Visibility.Hidden;
    }
