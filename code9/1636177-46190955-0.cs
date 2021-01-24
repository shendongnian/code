    public interface IMenu { ... }
    
    public class Menu : IMenu { ... }
    
    public class Menu2 : IMenu { ... }
    
    
    public List<IMenu> GetAllMenus()
        {
            List<IMenu> result = new List<Menu>();
            //Caching
            string CacheKey = "GetAllMenus";
            ObjectCache cache = MemoryCache.Default;
            if (cache.Contains(CacheKey))
                result= (List<IMenu>)cache.Get(CacheKey);
                return result;
    }
