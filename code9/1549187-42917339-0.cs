    public ActionResult Index()
    {
        User _user = db.Users.ToList();
        return Json(_user , JsonRequestBehavior.AllowGet);
    }
