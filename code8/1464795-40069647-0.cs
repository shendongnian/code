    public class ApplicationUserManager : UserManager<ApplicationUser>
        {
         // some code here
        internal async System.Threading.Tasks.Task<ApplicationUser>       FindByUsernameOrPhoneAsync(string  usernameOrPhone, string password)
            {
        var userManager= new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
                try
                {
                    // do your implementation here
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return requestedUser;
            }
        }
