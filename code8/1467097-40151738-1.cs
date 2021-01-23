    public ActionResult Index() 
    {
        var viewModel = new UserModel { FullName = // Logic for set };
        return View(viewModel);
    }
