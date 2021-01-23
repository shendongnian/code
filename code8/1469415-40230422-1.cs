     [HttpGet]
            public ActionResult Index()
            {
                var products = db.Products.ToList(); //Or some other IENUM
                return View(products);
    
            }
