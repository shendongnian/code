     [HttpGet]
            public ActionResult Index()
            {
                var products = db.Products.ToString();
                return View(products);
    
            }
