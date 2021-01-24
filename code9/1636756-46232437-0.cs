    public IHttpActionResult Post(footer_image_dets footer_image_detail)
        {
            if (ModelState.IsValid)
            {
                var parent = db.footer_images.Find(footer_image_detail.Id);
                if (parent != null) 
                {
                  parent.footer_image_dets.Add(footer_image_detail);
                  // it will work normally if you dont have child model(because  
                  // your foreign key is key and there cant be inserted second  
                  // row by same id, if you have child model you can update it,  
                  // it depends on your logic do you want to have one-to-one 
                  // reletion or no... )
                  db.SaveChanges();
                }
                else 
                {
                  //Create exception or yous specific logic here
                }
            }           
            return CreatedAtRoute("DefaultApi", new { id = footer_image_detail.id }, footer_image_detail);           
        }
