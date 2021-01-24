    [HttpGet]
    public ActionResult Index()
    {
       ViewModel vm = new ViewModel()
       {
          info = info,
          id = 0
       }
    
       return View(vm);
       //changed from below:
       //return View(info);
    }
