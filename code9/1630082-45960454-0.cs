    public ActionResult Index()
        {
            CMSEntities cx = new CMSEntities();
            Viewbag.student = cx.Students.ToList();
            return View();
        }
