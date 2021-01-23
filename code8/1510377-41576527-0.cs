    public MyConstructor()
    {
        StartTimer();
    }
    private void StartTimer()
    {
        Device.StartTimer(System.TimeSpan.FromSeconds(10), () => 
        {
            Device.BeginInvokeOnMainThread(UpdateUserDataAsync);
            return true;
        });
    }
    private async void UpdateUserDataAsync()
    {
        userdata = await UserService.GetUserasync(_UserViewModel.EmployeeId);
    }
