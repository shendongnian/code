    public class HelpController : Controller
    {
        private const string ErrorViewName = "Error";
		public HelpController()
			: this(GlobalConfiguration.Configuration)
		{
		}
		private HelpController(HttpConfiguration config)
		{
			Configuration = config;
		}
 
        
		public HttpConfiguration Configuration { get; private set; }
    }
