    public void amount()
    {
        var totalUsers = UserList.Count(user => user.User != "SYSTEM");
        Console.WriteLine("There has been {0} users on {1}",
        totalUsers, DateTime.Today.ToShortDateString());
    }
