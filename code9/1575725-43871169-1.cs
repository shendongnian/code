    foreach (DbEntityEntry dbEntityEntry in this.ChangeTracker.Entries())
    			{
    				if (dbEntityEntry.Entity != null)
    				{
                      // Here you can look at typeof and the EntityState
    				}
    			}
