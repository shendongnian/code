    public class ChangeLog  
    {
        public string EntityName { get; set; }
        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
    override int SaveChanges()  
    {
        var modifiedEntities = ChangeTracker.Entries()
            .Where(p => p.State == EntityState.Modified).ToList();
        foreach (var change in modifiedEntities)
        {
            var entityName = change.Entity.GetType().Name;
            foreach(var prop in change.OriginalValues.PropertyNames)
            {
                var originalValue = change.OriginalValues[prop].ToString();
                var currentValue = change.CurrentValues[prop].ToString();
                if (originalValue != currentValue)
                {
                    ChangeLog log = new ChangeLog()
                    {
                        EntityName = entityName,
                        PropertyName = prop,
                        OldValue = originalValue,
                        NewValue = currentValue,
                    };
                    ChangeLogs.Add(log);
                }
            }
        }        
        return base.SaveChanges();
    }
