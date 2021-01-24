      Logging.Log(LoggingMode.Prompt, "Saving Audid Entry{0}....", dbEntry.ToString()); 
            TableAttribute tableAttr = dbEntry.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), true).SingleOrDefault() as TableAttribute;
            string tableName = tableAttr != null ? tableAttr.Name : dbEntry.Entity.GetType().Name;
            Logging.Log(LoggingMode.Prompt, "TableName Retrived {0}...", tableName);
            switch (dbEntry.State)
            {
                case System.Data.Entity.EntityState.Added:
                    int result = base.SaveChanges();
                    object addedObj = dbEntry.Entity;
                    using (var audit = Audit.Core.AuditScope.Create("Add " + tableName, () =>addedObj ))
                    {
                        audit.SetCustomField("UserGUID", userGUID);
                        addedObj = null;
                    } 
                    return result;
                case System.Data.Entity.EntityState.Deleted:
                    object deletedObj = dbEntry.Entity;
                    using (var audit = Audit.Core.AuditScope.Create("Delete " + tableName, () => deletedObj))
                    {
                        audit.SetCustomField("UserGUID", userGUID);
                        deletedObj = null;
                    }  
                    break;
                case System.Data.Entity.EntityState.Modified: 
                    object en = dbEntry.OriginalValues.ToObject();
                    using (var audit = Audit.Core.AuditScope.Create("Edit " + tableName, () => en))
                    {
                        audit.SetCustomField("UserGUID", userGUID);
                        en = dbEntry.CurrentValues.ToObject();
                    }
                    break;
                default:
                    break;
            }
            return base.SaveChanges();
