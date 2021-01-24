    public ActionResult Create()
    {
       var vm=new YourVideModelClass();
       vm.CandidateOrderLine= new CandidateOrderLine();
       vm.SiteId = 3; // Hard coded for demo. Replace with valid SiteId
       return View(vm);
    }
