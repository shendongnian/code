     public class Auth: IAuthentication
    {
      private readonly ILog log;
      private IImpID impIDobj;
      public Auth(ILog log, IImpID impIDobj)
        {
            this.impIDobj= impIDobj;
            this.log = log;
        }
    
        [InjectionConstructor]
        public Auth()
            : this(LogManager.GetLogger("Auth"), new CAuth())
        {
        }
        public Authenticate()
        {
          impIDobj.Authenticate(data);
         //Some logics
        }
    }
