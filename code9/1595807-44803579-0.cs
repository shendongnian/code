    public ActionResult Update(int id) 
    {
        Foo foo = db.Foos.Find(id);
        foo.X = "new string";
    
        var entry = db.Entry(foo);
        entry.State = EntityState.Modified;
        
        db.SaveChanges();
        // Rest of code
    }
