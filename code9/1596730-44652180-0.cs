    [HttpPost]
            public JsonResult addProduct(ProductModels input)
            {
    
                Db.Products.Add(input);
                Db.SaveChanges();
                var products = Db.Products.ToList();
                return Json(products, JsonRequestBehavior.AllowGet);
            }
