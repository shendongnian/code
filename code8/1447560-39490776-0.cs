    public class MyUserStore : IUserStore<ApplicationUser>
    {
      private readonly MyOldDAL _dal = new MyOldDAL();
      public Task CreateAsync(ApplicationUser user)
      {
        var result = _dal.CreateUser(user.UserName);
        if (result.Success)
          return Task.CompletedTask;
        return Task.FromException(new InvalidOperationException(result.Message));
      }
    }
