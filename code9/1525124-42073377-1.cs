    private readonly CreateLotVm _navigationVm;
    public RelayCommand ButtonCommand;
    public AddLotPageVm(CreateLotVm navigationVm)
    {
        _navigationVm = navigationVm;
        ButtonCommand = new RelayCommand(ButtonMethod);
    }
    public void ButtonMethod(object x)
    {
        //...
        _navigationVm.CurrentPage = new Page2();
    }
