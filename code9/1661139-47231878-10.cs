    using (var context = new GenerateKeyContext(db2))
    {
        context.Database.Log = s => s.Dump();
        //context.Database.Delete();
        context.Database.Create();
    }
