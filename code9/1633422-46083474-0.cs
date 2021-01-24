    [HttpGet]
    public ActionResult Create()
    {
       // fill model to default data
       return view(model);
    }
    
    [HttpPost]
    public ActionResult Create(Person p)
    {     
       //do your stuff save data 
       return RedirectToAction("Create");      
    }
    or
    
    [HttpPost]
    public ActionResult Create(Person p)
    {     
       if(...)
       { 
         //do your stuff  any logic
         return RedirectToAction("Create");
       }
       //do your stuff 
         return view(...);
    }
     
