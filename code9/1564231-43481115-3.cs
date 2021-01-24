     [HttpPost]
        public ActionResult Index(string category ,string product)
        {
    
    
            ViewBag.x ="Product"+ product;
            ViewBag.y = "catego" + category;
            return View();
        }
