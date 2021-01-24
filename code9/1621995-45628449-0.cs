    public class MyUserStore: IUserStore<MyUser>, IQueryableUserStore<MyUser>
    {
        // critical method to bridge between HttpContext.User and your MyUser class        
        public async Task<MyUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            // that userId comes from the ClaimsPrincipal (HttpContext.User)
            var user = _users.Find(userId);
            return await Task.FromResult(user);
        }
    }
