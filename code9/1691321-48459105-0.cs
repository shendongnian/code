    public List<Users> GetUsers(object vmData)
    {
       vmData.Select(users=>new Users{
              Name = users.Name,
              Age = users.Age,
              Location = users.Location
          }).Tolist();
    }
