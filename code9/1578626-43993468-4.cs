    [HttpPost]
    public string UpdateUser(dynamic User)
    {
        var roles = User.Roles;
        var mail = User.Email;
        return mail;
    } 
