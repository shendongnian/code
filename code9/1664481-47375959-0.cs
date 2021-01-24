     public abstract class BaseController : Controller
    {
        protected UserManager<ApplicationUser> UserManager { get; }
        protected SignInManager<ApplicationUser> SignInManager { get; }
        protected IConfiguration Config { get; }
        protected IEmailSender EmailSender { get; }
        protected ILogger AppLogger { get; }
        protected BaseController(IConfiguration iconfiguration,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<ManageController> logger)
        {
            AppLogger = logger;
            EmailSender = emailSender;
            Config = iconfiguration;
            SignInManager = signInManager;
            UserManager = userManager; 
        }
        protected BaseController()
        {
        }
    }
