    public void Save(UserViewModel uv)
    {
        var user = MyRepository.GetUser(uv.Id);
        user.Name = uv.Name;
        user.Address = uv.Address;
        MyRepository.UpdateUser(user);
    }
