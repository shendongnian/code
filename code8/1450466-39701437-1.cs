    public class UserStore : IUserStore<UserModel>, IUserPasswordStore<UserModel>, IUserSecurityStampStore<TUser>
    {
        // your other methods
        
        
        public async Task SetSecurityStampAsync(TUser user, string stamp)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }
        Task<string> GetSecurityStampAsync(TUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return Task.FromResult(user.SecurityStamp);
        }
    }
