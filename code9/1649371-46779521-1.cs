    // Service
    private IUserDataProvider _provider;
    public List<UserModel> GetAllUsers()
    {
         var data = _provider.Get<User>();
         // massage your 'data' and return List<UserModel>
         . . . . 
    }
