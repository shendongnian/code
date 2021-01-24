    using (var db = new context()) {
        // get data from rest endpoint
        foreach (var item in array) {
            // try to retrieve existing entity
            var myEntity = db.MyEntity.Find(item.Id);
    
            // if entity does not already exist -> create new
            if (myEntity == null) {
                myEntity = new MyEntity();
                db.MyEntity.Add(myEntity);
            }
    
            // map received values
            myEntity.Property1 = item.Property1;
            myEntity.Property2 = item.Property2;
        }
                
        // EntityState should be set automatically by EF ChangeTracker
        db.SaveChanges();
    }
