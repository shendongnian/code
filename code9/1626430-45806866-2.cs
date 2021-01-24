    public NavigationParameters np = new NavigationParameters();
    
        // magic code everywhere
    
        private async void LoginAsync()
            {
                var user = await LoginAttemptAsync(_awsomePassword);
    
                np.Add("UserName", user.name);
    
                await _navigationService.NavigateAsync("MasterPage", np);
            }
