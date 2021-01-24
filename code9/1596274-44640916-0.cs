    public partial class MyService : ServiceBase
    {
         private MyContext myContext { get; set; }
         private ApplicationUserManager UserManager { get; set; }
         ...
         public void Dispose()
         {
             myContext.Dispose 
         }
    }
