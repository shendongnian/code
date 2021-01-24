    public WindowViewModel(Label userName)
    {
        var us = GetUsers.Where(u => u.Id == 1) as Users;
        userName.Content = us.Name.ToString();
    }
