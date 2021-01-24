    ViewModel.FirstVm vm1;
    public ViewPage(Models.Example example)
    {
        InitializeComponent();`
        BindingContex = new YourViewModel(parameters)
        NavigationPage.SetTitleIcon(this, "logosmall.png");
        Tasks ts = new Tasks();
        var myLocation = Task.Run(() => 
        ts.GetDeviceCurrentLocation()).Result;
        var latitudeIm = myLocation.Latitude;
        var longitudeIm = myLocation.Longitude;
        routeInfo.Command = vm1.GetInfoCommand;
        routeInfo.CommandParameter = latitudeIm;
        routeInfo.CommandParameter = longitudeIm;
        routeInfo.CommandParameter = latitude;
        routeInfo.CommandParameter = longitude;
    }
