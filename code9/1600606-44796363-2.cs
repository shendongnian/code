    public ActionResult ViewAction()
    {
    MainPageModel objMainPageModel = new MainPageModel();
    objMainPageModel.ProductsListViewModel = new ProductsListViewModel();
    objMainPageModel.ProductsListViewModel= //Bind this model as well
    
    //Bind Data in objMainPageModel and return to view
    return View("List", objMainPageModel)
    }
