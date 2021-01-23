    using System;
    using Microsoft.AspNetCore.Mvc;
    using NuGet.Protocol.Core.v3;
    
    namespace Potato
    {
        [Route("api/[controller]")]
        public class MailgunController : Controller
        {
            [HttpPost]
            public IActionResult Post()
            {
                MailgunEmail email = new MailgunEmail(Request);
    
                return Ok(email.ToJson());
            }
        }
    }
