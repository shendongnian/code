    public ActionResult Index(string selectedStatus="")
    {
      var vm= new ListAndSearchVm();
      //Hard coding 2 items for demo. You can read this from your db table
      vm.Statuses = new List<SelectListItem> {
         new SelectListITem { Value="Open", Text="Open"},
         new SelectListITem { Value="Closed", Text="Closed"},
      };
      var data= dbContext.Masters;
      if(!String.IsNullOrEmpty(selectedStatus))
      {
         data = data.Where(f=>f.Status.Name==selectedSatatus);
      }      
      vm.Data = data.ToList();
      return View(vm);
    }
