    using (DatabaseContext _db = new DatabaseContext())
    {
       await _db.Database.ExecuteSqlCommandAsync(query, paramsList);
    }
    using (DatabaseContext _db = new DatabaseContext())
    {
       var itemsJustInserted = _db.Items.ToList(); //should have your modified items
    }
