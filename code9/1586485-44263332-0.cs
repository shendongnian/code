    public IEnumerable<Registry> GetTableData()
    {
        IQueryable<Registry> _registries = _entities.Registry;
        IEnumerable<Registry> data = _registries
            .Include(x => x.Attachments)
            .Include("Attachments.AttachmentType")
             // here do necessary filtering with Where()
             // ...
      
        return data;
    }
