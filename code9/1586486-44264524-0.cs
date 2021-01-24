    public IEnumerable<Registry> GetTableData()
        {
            IQueryable<Registry> _registries = _entities.Registry,where(m=>m.IsDeleted==false);
            IEnumerable<Registry> data;
            data = _registries     .Include(p=>p.Attachments.Where(x=>x.IsDeleted==false)).
     include(p=>p.AttachmentType).AsEnumerable();
            return data;
        }
