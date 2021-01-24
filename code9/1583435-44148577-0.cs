    var science = new Class();
    science.Name = "Sci-101";
    
    science.Students.Add(new Student { Name = "Tom" });
    science.Students.Add(new Student { Name = "Jerry" });
    using (var dbCtx = new SchoolDBEntities())
    {
        // Add the class
        dbCtx.Classes.Add(science);
        // Save whole entity graph to the database.
        // You do not need to save the students separately since they are part
        // of the class. We have already added them to the class so saving the 
        // class will save the students added to the class as well.
        dbCtx.SaveChanges();
    }
