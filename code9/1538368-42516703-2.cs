    // GET option/1
    [HttpGet]
    [Route("option/{id:int}")] 
    public ActionResult GetOption(int id, bool advanced = false) {
        //...    
        return View("Option");
    }
    // GET option/1/advanced
    [HttpGet]
    [Route("option/{id:int}/advanced")]
    public ActionResult GetAdvancedOption(int id) {
        return GetOption(id, true);
    }
