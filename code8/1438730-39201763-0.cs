    public ActionResult Index()
    {
        if (IsDbExists())
        {
            _contactList = new List<Contact>();         
            UpdateOperations();
            return View(_contactList);
        }
        return RedirectToAction("actionname", "controllername");
    }
