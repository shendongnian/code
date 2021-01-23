    public MyRandomToastGeneratingViewModel(ToastService toastService)
    {
        //our service is inejcted as a dependency
        this.toastService = toastService;
    }
    public void ShowAToastButtonPressed()
    {
        toastService.ShowToast("My great toast!");
    }
