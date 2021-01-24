    var list = new List<User>();
    for(var i = 0; i < models.Count/3; i++)
    {
        var user = new User();
        user.Id = (int)models[string.Format("Users[{0}].Id", i)];
        user.Name = models[string.Format("Users[{0}].Name", i)].ToString();
        user.Email = models[string.Format("Users[{0}].Email", i)].ToString();
        list.Add(user);
    }
