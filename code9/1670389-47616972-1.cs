       public class Test
        {
            ConcurrentHashSet hashSet = new ConcurrentHashSet();
            public Test() 
            {
                foreach (var set in hashSet.GetItemsById(123))
                {
                }
            }
           
        }
        public class ConcurrentHashSet : HashSet<ConcurrentHashSet>
        {
            public static ConcurrentHashSet Items = new ConcurrentHashSet();
            public Boolean HasLoaded { get; set; }
            public int Id { get; set; }
            public List<ConcurrentHashSet> GetItemsById(int id)
            {
                return Items.Where(x => x.HasLoaded && x.Id == id).ToList();
            }
        }
