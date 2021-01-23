    // POST:
    [HttpPost]
    public ActionResult Edit([Bind(Include = "id,title,content,price)] Product product)
    {
    	var original_data = db.Products.AsNoTracking().Where(P => P.id == product.id).FirstOrDefault();
    	
    	/* Use original_data.title here */
    
    	db.Entry(product).State = EntityState.Modified;
    	db.SaveChanges();
    }
