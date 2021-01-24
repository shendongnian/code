    public class UserManager : UserManager<ApplicationUser>
    {
        private ApplicationDbContext _dbAccess;
        public UserManager(ApplicationDbContext dbAccess) : 
             base(new UserStore<ApplicationUser>(dbAccess))
        {
            ...
    
            this._dbAccess = dbAccess; 
        }
        ...
    }
