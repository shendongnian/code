    if (allUsers.Any(x => x.Username.Equals(Username) && x.Password.Equals(Password)))
    {
        var user = allUsers.Where(x => x.Username.Equals(Username) && x.Password.Equals(Password)).First();
        Application.Current.MainPage.Navigation.PushAsync(new MainPage(user));
    }
