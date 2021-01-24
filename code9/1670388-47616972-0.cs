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
        public class Item
        {
            public Boolean HasLoaded { get; set; }
            public int Id { get; set; }
        }
        public class ConcurrentHashSet : HashSet<Item>
        {
            public ConcurrentHashSet GetItemsById(int id)
            {
                return new ConcurrentHashSet();
            }
        }
