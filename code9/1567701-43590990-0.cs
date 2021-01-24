    public void Clone(int id)
    {
        // Stop tracking changes to the object.
        var incident = _context.AsNoTracking().FirstOrDefault(i => i.Id == id);
        // Setting back to 0 should treat the object Id as unset.
        incident.Id = 0;
    
        // Add the Incident while it is untracked will treat it as a new entity.
        _context.Incidents.Add(incident);
        _context.SaveChanges();
    }
