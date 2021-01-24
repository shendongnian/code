     public ActionResult MyProductDetails(int? id) // If your id is not nullable then you can remove ? mark
      {
        List<ProductViewModel> Products = new List<ProductViewModel>();
        if(id!=null)   
        {
         Products = storeDB.Products.where(m=>m.categoryId == id).ToList(); // You can fetch the product as you like 
         return View(Products);
        }
        else
         return View(Products); // It will return null
      }
