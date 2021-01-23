    public class CurrentUserService : ICurrentUserService
    {
      public LoginName
       {
         get
           {
              return HttpContext.Current.User.Identity.Name;
           }
        }
     }
