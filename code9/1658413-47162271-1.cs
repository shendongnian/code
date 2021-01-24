    public IActionResult Index()
    {
       	var vm = _service.GetViewModel();
    
       	vm.TitleKey = "Title.Translation.Key";
    
        Translate(vm);
       	return View(vm);
    }
