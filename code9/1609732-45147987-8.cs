    [HttpGet]
    public ActionResult Index()
    {
        List<Test> vm = (List<Test>)Session["Test"];
    
        if (vm == default(List<Test>))
        {
            vm = new List<Test>
            {
                new Test { str="one"},
                new Test { str="two"},
                new Test { str="three"},
                new Test { str="four"},
                new Test { str="five"},
                new Test { str="six"},
                new Test { str="seven"}
             };
             Session.Add("Test", vm);
        }                    
      
        return View(vm);
    }
        
    [HttpPost]
    public ActionResult Index(List<Test> vm)
    {
        Session.Add("Test", vm);
        return RedirectToAction("Index");
    }
