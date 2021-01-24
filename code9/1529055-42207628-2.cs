    public class GenericUserStore<TUser> : IUserStore<TUser>,
        IUserPasswordStore<TUser> where TUser : ApplicationUser
    {
        public GenericUserStore(IRepository<TUser> userRepo) { }
        public Task<TUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return userRepo.Get(userId);
        }
        ...
    }
