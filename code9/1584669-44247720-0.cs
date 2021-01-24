    using (myDbEntities db = new myDbEntities())
    {
        //for all the entities to update...
        MyObjectEntity entityToUpdate = new MyObjectEntity() {Id=123, Quantity=100};
        db.MyObjectEntity.Attach(entityToUpdate);
        
        //then perform the update
        db.SaveChanges();
    }
