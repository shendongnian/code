    private async void HomeButtonClick(object obj)
    {
        if (CurrentPage != null && CurrentPage is HomeViewModel)
        {
            CurrentPage = null;
            await Task.Delay(1);
        }
        CurrentPage = new HomeViewModel();
    }
