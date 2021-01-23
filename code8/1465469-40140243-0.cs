    public class SDPContext : ISDPContext
    {
        private ITypeResolver _typeResolver;
        public Account CurrentUser { get; set; }
        public IAccountService AccountService
        {
            get
            {
                // lazy load the account service
            }
        }
        public ISchoolService SchoolService
        {
            get
            {
                // lazy load the schoolservice
            }
        }
        public SDPContext(ITypeResolver typeResolver)
        {
            this._typeResolver = typeResolver;
        }
    }
    public class ServiceBase
    {
        public ISDPContext CurrentContext { get; set; }
        public ServiceBase(ISDPContext context)
        {
            this.CurrentContext = context;
        }
    }
    public class AccountService : ServiceBase, IAccountService
    {
        public AccountService(ISDPContext context) : base(context)
        {
            
        }
        public bool ResetAccount(int accountId)
        {
            // use base.Context.SchoolService to access the school business
        }
    }
    public class SchoolService : ServiceBase, ISchoolService
    {
        public SchoolService(ISDPContext context) : base(context)
        {
            //this._accountService = accountService;
        }
        public void RenewRegistration(int accountId)
        {
            // use the base.Context.Account service to access the account service
        }
    }
