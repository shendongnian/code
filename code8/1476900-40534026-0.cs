    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext context)
            :base(context)
        {
        }
        public override Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Users
                .Include(u => u.Municipality)
                .Include(u => u.Roles)
                .Include(u => u.Claims)
                .Include(u => u.Logins)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
