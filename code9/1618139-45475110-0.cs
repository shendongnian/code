    public class MyController : BaseController
    {
        public MyController(ApplicationDbContext context, IIdentityService identityService)
             :base(conext, identityService)
        {
        } 
