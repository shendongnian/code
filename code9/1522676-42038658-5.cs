    using (var db = new AppDbContextWithIdentity())
    {
        using(var tx = db.Database.BeginTransaction()){
           var item = new IdentityItem {Id = 418, Name = "Abrahadabra" };
           db.IdentityItems.Add(item);
           db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Test.Items ON;");
           db.SaveChanges();
           db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Test.Items OFF");
           tx.Commit();
        }
    }
