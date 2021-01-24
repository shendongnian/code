    public void UpdateUser(UserModel userViewModel)
    {
        var userEntity = DBContext.Users.Find(userViewModel.Id);  // Get your user from database
        Mapper.Map(userViewModel, userEntity);  // Use Automapper to move the changed fields into your entity
        DbContext.SaveChanges();
    }
