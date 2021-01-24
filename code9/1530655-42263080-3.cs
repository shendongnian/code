    [RoutePrefix("WhatEver")]
    public class WhatEverController : Controller {
        //GET whatever
        [HttpGet]
        [Route("")]
        public ActionResult Index() { ... }
    }
