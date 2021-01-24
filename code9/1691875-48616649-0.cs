    if (ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.AcrylicBrush"))
    {
                        var brush= ((SolidColorBrush)App.Current.Resources["ExampleBrush"]).Color;
                        App.Current.Resources["ExampleBrush"] = new AcrylicBrush()
                        {
                            TintOpacity = ,
                            TintColor = brush,
                            FallbackColor = brush,
                            BackgroundSource = AcrylicBackgroundSource.HostBackdrop
                        };
    }
