    public ActionResult Index()
            {
                Compra compra = new Compra();
                compra.ID = "1";
                compra.ComboList.Add(new Combo { ID = "1", NAME = "Element 1" });
                compra.ComboList.Add(new Combo { ID = "2", NAME = "Element 2" });
                compra.ComboList.Add(new Combo { ID = "3", NAME = "Element 3" });
                compra.ComboList.Add(new Combo { ID = "3", NAME = "Element 4" });
                compra.ComboList.Add(new Combo { ID = "3", NAME = "Element 5" });
                ViewBag.compra = compra;
    
                return View();
            }
