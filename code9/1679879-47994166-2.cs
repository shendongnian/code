     public void Save(UserViewModel uv)
     {
        // this throws error: cannot convert from UserViewModel to Entity.User
       var config = new MapperConfiguration(cfg => {
    
                    cfg.CreateMap<UserViewModel , User>();
    
                });
        User u = config.CreateMapper().Map<User>(uv)
        MyRepository.UpdateUser(u);
     }
