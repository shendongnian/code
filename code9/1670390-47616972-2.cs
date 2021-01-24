       public class Test
        {
            ConcurrentHashSet hashSet = new ConcurrentHashSet();
            public Test() 
            {
                foreach (ConcurrentHashSet set in hashSet.GetItemsById(123))
                {
                }
            }
           
        }
        
        public class ConcurrentHashSet : HashSet<ConcurrentHashSet>
        {
            public Boolean HasLoaded { get; set; }
            public int Id { get; set; }
            public List<ConcurrentHashSet> GetItemsById(int id)
            {
                return this.Where(x =>  x.HasLoaded && x.Id == id).ToList();
            }
        }
