    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Rooms([Bind(Include = "ID,BedroomCount,BedroomsDescription,BathroomCount,BathroomsDescription")] Property property)
    {
        if (ModelState.IsValid)
        {
            // try this read this entoity from context and update properties you need to update
           var dbproperty = db.Property.FirstOrDefault(x=>x.Id= property.Id); // handle null 
            //Modify property
            dbproperty .DateModified = DateTime.Now;
            dbproperty .Status = 1;      
            
           // assuming in your context class Properties is the name of table.
             db.Entry(dbproperty ).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(property);
    }
