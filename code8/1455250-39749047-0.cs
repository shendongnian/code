    [RoutePrefix("Area")]
    public AreaController : Controller {
        //GET Area
        [Route("")]
        [HttpGet]
        public ActionResult Index() {
            // List of things
            return View();
        }
        //GET Area/123
        [Route("{id:int}")]
        [HttpGet]
        public ActionResult Detail(int id) {
            // Specific 'thing'
            return View();
        }
        //POST Area
        [Route("")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(MyViewModel myViewModel) {
            // 'Thing' has just been posted
            return View();
        }
    }
