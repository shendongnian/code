    if(ModelState.IsValid)
            {
                var dbData = db.Data.Find(data.ID);
                dbData.Name = data.Name
               
                if(image1 != null)
                {
                    dbData.Image = new byte[image1.ContentLength];
                    image1.InputStream.Read(dbData.Image, 0, image1.ContentLength);
                }              
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
    
            return View(data);
