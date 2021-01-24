    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Localization;
    using static Localization.StarterWeb.LocalizationKeys; // Note: static keyword
    
    namespace Localization.StarterWeb.Controllers
    {
        [Route("api/[controller]")]
        public class AboutController : Controller
        {
            private readonly IStringLocalizer<AboutController> _localizer;
    
            public AboutController(IStringLocalizer<AboutController> localizer)
            {
                _localizer = localizer;
            }
    
            [HttpGet]
            public string Get() => _localizer[AboutTitle]; // Note: omission of qualifier
        }
    }
