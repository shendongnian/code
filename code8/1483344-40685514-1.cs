    public class DiscussionController : Controller
    {   
        private readonly IDataProtector _dataProtector;        
           
        public DiscussionController(IDataProtectionProvider dataProtectionProvider)
        {
            var protectorPurpose = "whatever purpose you want";
            _dataProtector = dataProtectionProvider.CreateProtector(protectorPurpose);
        }
        
        public IActionResult Index()
        {     
           HttpContext.Request.Cookies.TryGetValue(".AspNetCore.Session", out string cookieValue);
        
           var protectedData = Convert.FromBase64String(Pad(cookieValue));
        
           var unprotectedData = _dataProtector.Unprotect(protectedData);
        
           var humanReadableData = System.Text.Encoding.UTF8.GetString(unprotectedData);
        
            return Ok();
        }
        
        private string Pad(string text)
        {
            var padding = 3 - ((text.Length + 3) % 4);
            if (padding == 0)
            {
                return text;
            }
            return text + new string('=', padding);
        }    
    }
