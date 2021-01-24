    public ActionResult Edit(decimal id){
         var product = _db.Products.Single(p => p.Id == id);
         if(product == null)
              return HttpNotFound();
    
         return Json(product, JsonRequestBehavior.AllowGet);
    }
