    IQueryable<Entity> GetSortedData(IQueryable<Entity> result, String orderby, bool desc)
    {
       switch (orderby.ToLowerInvariant())
       {
         case "id":
             return desc ? result.OrderByDescending(c => c.Id) : result.OrderBy(c => c.Id);
         case "code":
             return desc ? result.OrderByDescending(c => c.Code) : result.OrderBy(c => c.Code);
         case "active":
             return desc ? result.OrderByDescending(c => c.Active) : result.OrderBy(c => c.Active);
         default:
             return desc ? result.OrderByDescending(c => c.Name) : result.OrderBy(c => c.Name);
       }
    }
