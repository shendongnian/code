    var dbcontext = new ApplicationDbContext(); //foo table is empty
    var entry = new Entry { DateTime = DateTime.Now };
    dbcontext.Foo.Add();
    dbcontext.SaveChanges();
    dbcontext.Entry(entry).Reload(); //doesnt suffer from the quirks of dbcontext.Gigs.First()
