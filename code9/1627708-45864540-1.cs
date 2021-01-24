    public ActionResult Create()
    {
      var vm=new MyViewModel();
      vm.Items = new List<SelectListItem>{
         new SelectListItem { Value="1", Text="1" },
         new SelectListItem { Value="2", Text="2" },
         new SelectListItem { Value="3" , Text="3"}
      };
    
      vm.SelectedVal = "2";  // This will pre select the second item in dropdown
    
      return View(vm);
    }
