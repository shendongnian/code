            [ValidateAntiForgeryToken]
            public ActionResult GetProducts()
            {
                return Json(products);
            }
    
            [ValidateAntiForgeryToken]
            public void UpdateProduct(Product updatedProduct)
            {
                var product = products.FirstOrDefault(p => p.ID == updatedProduct.ID);
                UpdateModel(product);
            }
