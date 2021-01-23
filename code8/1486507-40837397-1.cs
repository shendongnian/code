    return DbContext.Entity
         .AsNoTracking()
         .Where(e => e.DateDelete == null)
         .Select(e => new
             {
                 e.Id,
                 e.Property,
                 e.DateDelete,
                 SubEntities = e.SubEntities.Where(se => se.DateDelete == null)
             })
         .ToList();
