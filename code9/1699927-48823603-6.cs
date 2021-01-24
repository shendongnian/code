    const string tableName = "Entity1";
    using (var db = OpenDbConnection())
    {
        db.DropAndCreateTable<GenericEntity>(tableName);
        db.Insert(tableName, new GenericEntity { Id = 1, ColumnA = "A" });
        var rows = db.Select(tableName, db.From<GenericEntity>()
            .Where(x => x.ColumnA == "A"));
        Assert.That(rows.Count, Is.EqualTo(1));
        db.Update(tableName, new GenericEntity { ColumnA = "B" },
            where: q => q.ColumnA == "A");
        rows = db.Select(tableName, db.From<GenericEntity>()
            .Where(x => x.ColumnA == "B"));
        Assert.That(rows.Count, Is.EqualTo(1));
    }
