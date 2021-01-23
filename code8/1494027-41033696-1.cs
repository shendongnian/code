    public void DeleteAll()
    {
        List<Record> records = new List<Record>() {
            new Record() { id = 1, value = 5 },
            new Record() { id = 2, value = 10 }
        };
        using(SomeContext ctx = new SomeContext()) {
            ctx.Configuration.AutoDetectChangesEnabled = false;
            foreach(var item in records)
            {
                ctx.Entry(item).State = EntityState.Deleted;
            }
            ctx.ChangeTracker.DetectChanges();
            ctx.SaveChanges();
        }
    }
