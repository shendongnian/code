    public ActionResult Index()
    {
      var vm=new ListViewModel();
      vm.SinglesData = db.Data
                         .Where(a=> a.hidden == false && a.collection == "Singles").ToList();
      vm.TownsData = db.Data
                       .Where(b=> b.hidden == false && b.collection == "Towns").ToList();
      return View(vm);
    }
