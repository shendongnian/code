    public ActionResult Index(){
        return View();
    }
    [HttpPost]
    public ActionResult Index(ViewModelThatSuitsYourNeeds vm){
    //Do your magic here
    ResultViemModel resultVM= //your magic;
    return View(vm);
    }
  
