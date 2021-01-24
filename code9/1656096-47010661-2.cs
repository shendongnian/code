    IEnumerable<MyClass> readItems = ConvertTxtFile(fileName);
    using (var dbContext = new MyDbContext())
    {
        dbContext.MyClasses.AddRange(readItems.ToList());
        dbContext.SaveChanges();
    }
