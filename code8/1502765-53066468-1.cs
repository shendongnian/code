    public dynamic GetTestUsers()
    {
        var testUsers = Configuration.GetSection("TestUsers")
                        .GetChildren()
                        .ToList()
                        .Select(x => new {
                            UserName = x.GetValue<string>("UserName"),
                            Email = x.GetValue<string>("Email"),
                            Password = x.GetValue<string>("Password")
                        });
        return new { Data = testUsers };
    }
