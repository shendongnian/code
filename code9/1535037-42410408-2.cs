    public interface IFilterableByFlags<T>
    {
      Dictionary<string, Func<T, bool, bool>> GetFilters();
      IEnumerable<T> ApplyFilters(IEnumerable<T> collection, Dictionary<string, bool> filterValues);
    }
    public class FooFilters : IFilterableByFlags<fooClass>
    {
      public Dictionary<string, Func<fooClasss, bool, bool>> GetFilters()
      {
        var filters = new Dictionary<string, Func<fooClass, bool, bool>>();
        filters["AdminAccess"] = (obj, val) => obj.AdminAccess == val;
        filters["ChildRestrictions"] = (obj, val) => obj.ChildRestrictions == val;
        return filters;
      }
      
      public IEnumerable<fooClass> ApplyFilters(IEnumerable<fooClass> collection, Dictionary<string, bool> filterValues)
      {
        var filters = GetFilters();
        
        // this could be written using Linq Aggregate, but I prefer an
        // explicit loop. Simpler error handling (omitted here for brevity)
        foreach(var f in filtervalues)
        {
          collection = collection.Where(foo => filters[f.Key](foo, f.Value));
        }
        
        return collection;
      }
    }
