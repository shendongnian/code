    public ActionResult Index()
    {
        MyViewModel vm= new MyViewModel();
        var vm = (from c in db.Customers
                 join o in db.Orders
                 select new Tuple<string, int>(c.Name, o.OrderNo).ToList();
                return View(vm);
    }
