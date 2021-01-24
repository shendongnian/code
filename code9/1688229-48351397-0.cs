    using (var db = new MyContextDB())
    {
    
        var result = db.rental.SingleOrDefault(r => id == ID);
        if (result != null)
        {
            result.SomeValue = "Some new value";
    
            db.Configuration.ValidateOnSaveEnabled = false; // <-- set flag to false
            db.SaveChanges();
        }
    }
