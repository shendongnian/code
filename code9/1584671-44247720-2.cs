    using (myDbEntities db = new myDbEntities())
    {
        try
        {
          //disable detection of changes to improve performance
          db.Configuration.AutoDetectChangesEnabled = false;
          //for all the entities to update...
          MyObjectEntity entityToUpdate = new MyObjectEntity() {Id=123, Quantity=100};
          db.MyObjectEntity.Attach(entityToUpdate);
        
          //then perform the update
          db.SaveChanges();
        }
        finally
        {
          //re-enable detection of changes
          db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
