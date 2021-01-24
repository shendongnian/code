    public abstract class OutputCacheProvider : ProviderBase
     {
       public abstract object Get(string key);
       public abstract object Add(string key, object entry, DateTime utcExpiry);
       public abstract void Set(string key, object entry, DateTime utcExpiry);
       public abstract void Remove(string key);
     }
