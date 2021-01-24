    public WindowViewModel(Label userName)
    {
        var us = GetUser(u => u.Id == 1);
        userName.Content = us.Name.ToString();
    }
