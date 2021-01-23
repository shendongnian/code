    public partial class MyEntities : ObjectContext
        {
            public override int SaveChanges(SaveOptions options)
            {
                this.DetectChanges();
    
                foreach (var insert in this.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Added))
                {
                    if (insert.Entity.GetType().GetProperty("CreatedDateTime") != null && insert.Entity.GetType().GetProperty("CreatedDateTime").GetType().Name == "DateTime" && (DateTime)(insert.Entity.GetType().GetProperty("CreatedDateTime").GetValue(insert.Entity)) == DateTime.Parse("0001-01-01 00:00:00.0000000"))
                        insert.Entity.GetType().GetProperty("CreatedDateTime").SetValue(insert.Entity, DateTime.UtcNow, null);                
                }
                return base.SaveChanges(options);
            }
        }
