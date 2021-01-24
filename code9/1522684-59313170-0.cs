    using (var db = new AppDbContext())
    {
        db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Test.Items ON;");
        using (var transaction = db .Database.BeginTransaction())
        {
           var item = new IdentityItem {Id = 418, Name = "Abrahadabra" };
           db.IdentityItems.Add(item);
           db.SaveChanges();
           transaction.Commit();
        }
        db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Test.Items OFF");
    }
