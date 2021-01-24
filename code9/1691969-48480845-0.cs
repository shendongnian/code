    class Cache 
    {
       ImmutableHashSet<string> cache = ImmutableHashSet.Create<string>();
    
       public IEnumerable<string> GetAllEntries()
       {   
           return cache;
       }
    
       public void Add(string newEntry) 
       {
           ImmutableInterlocked.Update(ref cache, (set,item) => set.Add(item), newEntry);
       }
    
       public void Remove(string entryToRemove)
       {
           ImmutableInterlocked.Update(ref cache, (set,item) => set.Remove(item), newEntry);
       }
    }
