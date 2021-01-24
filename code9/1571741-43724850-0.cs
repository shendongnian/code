    [Route("")]
    [Route("Index/{id:int?}")]
    [Route("My/Index/{id:int?}", Name = "MyCompleteRouteName")]
    [Route("{id:int?}")]    
    public ActionResult Index(int? id)
    {
         var viewModel = new GroupViewModel();
    ....
         return View("Index", viewModel);
    }
