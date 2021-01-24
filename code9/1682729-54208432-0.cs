     [Authorize(Policy = "AdUser")]
    public class FTAControllerBase : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogHandler _logger;
        public FTAControllerBase(ApplicationDbContext DbContext, ILogHandler Logger, IWindowsAccountLinker WinAccountLinker)
        {
            _db = DbContext;
            _logger = Logger;
            /// get registered user via authenticated windows user.
            //var user = WinAccountLinker.LinkWindowsAccount();
        }
