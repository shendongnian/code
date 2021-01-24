    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        foreach (DbEntityEntry entry in _dbContext.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
                case EntityState.Deleted:
                entry.State = EntityState.Modified; //Revert changes made to deleted entity.
                    entry.Reload() //OR entry.State = EntityState.Unchanged;;
                    break;
            }
        }
    } 
