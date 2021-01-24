    public App()
    {
        var content = new ContentPage
        {
            Title = "consumerestful",
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Welcome to Xamarin Forms!",
                    }
                }
            }
        };
        MainPage = new NavigationPage(content);
    }
    public async override void OnAppearing()
    {
        // The root page of your application
        await RefreshDataAsync();
        var test = people;
    }
