    public ActionResult Index()
    {
        // just show the page
        return View();
    }
    [HttpPost]
    public ActionResult Index(SQL_Blocks_App.Models.DropdownList SelectedValue)
    {
        // receive data from the page
        // perform some operation
        // and show the page again
        return View();
    }
