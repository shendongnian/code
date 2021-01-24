    db.Database.ExecuteSqlCommand("disable trigger all on  Test.Items;") 
    db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Test.Items ON;");
    db.SaveChanges();
    db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Test.Items OFF");
    db.Database.ExecuteSqlCommand("enable trigger all on  Test.Items;") 
 
