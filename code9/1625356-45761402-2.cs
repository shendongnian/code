    IQueryable<Entity> GetSortedData(IQueryable<Entity> result, String orderby, bool desc)
    {
       switch (orderby.ToLowerInvariant())
       {
         case "id": return result.OrderBy(c => c.Id, desc);
         case "code": return result.OrderBy(c => c.Code, desc);
         case "active": return result.OrderBy(c => c.Active, desc);
         default: return result.OrderBy(c => c.Name, desc);
       }
    }
