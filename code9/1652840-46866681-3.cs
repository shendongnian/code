    public ActionResult FileUpload(ProductImageVm model)
    {
       if (model.Image != null)
       {
          var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
          var fileId = GetUniqueName(model.Image.FileName);
          var filePath = Path.Combine(uploads,fileId);
          model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
        }
        // to do  : Save the record in ProductImage table
        var pi=new ProductImages { ProductId = model.ProductId};
        pi.ProductImageTitle = model.Title;
        pi.ProductImageRealPath = fileId; //Storing the fileId
        db.ProductImages.Add(pi);
        db.SaveChanges();
        return RedirectToAction("Index", "Home");
    
    }
               
 
