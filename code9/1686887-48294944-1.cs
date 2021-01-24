    public ICommand GetInfoCommand
    {
        get
        {
            return new Command<List<double>>(async (List<double> list) =>
            {
                Routes = await _ts.GetRouteInfosAsync(list[0], list[1], list[2], list[3]);
                await Application.Current.MainPage.Navigation.PushAsync(new View(Routes));
            });
        }
    }
    //use this command in ViewPage
    routeInfo.CommandParameter = new List<double> { latitude, longitude, latitudeIm, longitudeIm };
