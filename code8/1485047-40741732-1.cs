     IEnumerable<PackSizeTypeObject> MyPackSizeTypeObjects(bool? isActive)
    {
    
    return await (from p in db.PackSizeTypes.AsNoTracking()
              where  p.Active == (isActive == null ? p.Active : isActive)
              orderby p.ID
     select new PackSizeTypeObject
          {
              ID = p.ID,
              Name = p.Name.Trim(),
              LastEditedDate = p.LastEditedDate,
              LastEditedBy = p.LastEditedBy,
              Active = p.Active
          }).ToListAsync();
    }
