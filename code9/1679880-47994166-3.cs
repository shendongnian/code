     public void Save(UserViewModel uv)
     {
        User u = new User()
          {
            Id = uv.Id
            Name = uv.Name;
            Address = uv.Address;
          }
        MyRepository.UpdateUser(u);
     }
