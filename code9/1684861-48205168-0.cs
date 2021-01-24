    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    
    namespace Viber.Pages
    {
        public class TestModel : PageModel
        {
            private Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
            public TestModel(Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
            {
                _env = env;
            }
    
            public void OnGet()
            {
                // use the _env here
            }
        }
    }
