    private readonly CreateLotVm _navigationVm;
    public AddLotPage(CreateLotVm navigationVm)
    {
        _navigationVm = navigationVm;
    }
    public void Button_Click(object sender, RoutedEventArgs e)
    {
        //...
        _navigationVm.CurrentPage = new Page2();
    }
