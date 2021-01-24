    using (var db = new AppDbContext())
    {
        var item = new IdentityItem {Id = 418, Name = "Abrahadabra" };
        db.IdentityItems.Add(item);
        db.Database.Connection.Open();
        db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Test.Items ON;");
        db.SaveChanges();
    }
