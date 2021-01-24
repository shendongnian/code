        public ActionResult Product(id)
        {
            Product product = _productBL.GetProduct(id);
            return PartialView("~/Views/Shared/Product.cshtml", product, new ViewDataDictionary { Foo = "Weeeeeeee!!!" });
        }
