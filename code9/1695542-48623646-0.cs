    public class MyStore : IUserStore<IdentityUser>, // the rest of the interfaces
    {
        // ... implement the dozens of methods
        public async Task<IdentityUser> FindByEmailAsync(string normalizedEmail, CancellationToken token)
        {
            return await context.Users
                .Include(x => x.Address)
                .SingleAsync(x => x.Email == normalizedEmail);
        }
    }
