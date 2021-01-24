    var _data = db.tablename.Where(x => codition ).ToList();
    _data.ForEach(x =>
    {
        db.Entry(x).State = System.Data.Entity.EntityState.Deleted;
    });
    db.SaveChanges();
