    public class Cache 
    {     
        private object guard = new object();
        var cache = new SomeImmutableCollection<string>();
       // this method gets called frequently
       public IEnumerable<string> GetAllEntries()
       {   
           return cache;
       }
       // this method gets rarely called 
       public void Add(string newEntry) 
       {  
           lock (guard) 
           {
               cache = cache.Add(newEntry); 
           }
       }
       public void Remove(string entryToRemove)
       {
          lock (guard) 
          {
              cache = cache.Remove(entryToRemove);
          }
       } 
    }
