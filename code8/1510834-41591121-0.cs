    public void ProcessUsers()
    {
        _users = _dal.GetUsers();
        foreach(var u in users)
        {
            u.user.Comment = "This is a test";
            _dal.Users.Update(u);
        }
        _dal.SaveChanges();
    }
