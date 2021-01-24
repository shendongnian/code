    public void ResetStatistics()
    {
        _lisDatabase.Database.ExecuteSqlCommand("TRUNCATE TABLE Sortedtubes");
        _lisDatabase.sortedtubes.Local.Clear();
        foreach (var entry in _lisDatabase.ChangeTracker.Entries<Sortedtubes>())
        {
            _lisDatabase.Entry(entry).State = EntityState.Detached;
        }
    }
