    public class AccountController : BaseController
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
    }
    
    public interface IAccountRepository
    {
        Site TryGetCustomSite(string hostName);
         CultureInfo UpdateCustomerLanguage(int customerID, CultureInfo culture);
    }
    public class AccountRepository : IAccountRepository, BaseRepository
    {
        private readonly ITraxgoDB _context;
    
        public AccountRepository(ITraxgoDB context) {
            _context = context;
        }
    
        public Site TryGetCustomSite(string hostName)
        {
            var site = _context.Sites.FirstOrDefault(s => hostName.Contains(s.HostName));
            if (site != null && site.HostName != "traxgo")
                return site;
            return null;
        }
    
        public CultureInfo UpdateCustomerLanguage(int customerID, CultureInfo culture)
        {
            using (var ctx = new TraxgoDB(TraxgoDBRights.ReadWrite))
            {
                ...
            }
        }
    }
