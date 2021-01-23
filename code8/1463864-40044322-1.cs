    public IEnumerable<ResourceGroup> GetAllServersByApplication(string application_name, string environment_name, string status)
    {
        var query = _context.ResourceGroup
            .Include(a => a.Application)
            .Include(t => t.Type)
            .Include(e => e.ServersGroup).ThenInclude(e => e.Environment)
            .Include(s => s.ServersGroup).ThenInclude(s => s.Server)
            .Include(s => s.ServersGroup).ThenInclude(s => s.Server).ThenInclude(s => s.Status)
            .Where(a => a.Application.Name == application_name && a.ServersGroup.Any(s => s.Environment.Name == environment_name && s.Server.Status.Name == status))
            .ToList();
        return query;
    }
