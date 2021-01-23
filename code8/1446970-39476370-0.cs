    var dbcontext = new ApplicationDbContext(); //foo table is empty
    dbcontext.Foo.Add(new Entry { DateTime = DateTime.Now });
    dbcontext.SaveChanges();
    var dbcon2 = new ApplicationDbContext(); //vital
    var date = dbcon2.Foo.First().DateTime;
    
