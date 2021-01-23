    //"image" is the name of the html fileupload element
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Udstillingsmodel udstillingsmodel,HttpPostedFileBase image)
        {
        if (ModelState.IsValid)
        {
     //upload image
                if (image!= null && image.ContentLength > 0)
                {
                    try
                    {
    //Here, I create a custom name for uploaded image
                        string file_name = udstillingsmodel.titel + Path.GetExtension(image.FileName);
                        string path = Path.Combine(Server.MapPath("~/Content/images"), file_name);
                        image.SaveAs(path);
     // image_path is nvarchar type db column. We save the name of the file in that column. 
                        udstillingsmodel.image_path= file_name;
                    }
                    catch (Exception ex)
                    {
      
                    }
                }
            db.Udstillingsmodels.Add(udstillingsmodel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(udstillingsmodel);
    }
     
