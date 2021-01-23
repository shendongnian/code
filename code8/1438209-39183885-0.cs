    public class MyList : IList<int>
    {
        private List<int> underlyingList;
        private Broadcast entity;
    
        public MyList(Broadcast entity)
        {
             this.entity = entity;
             this.underlyingList = entity.DbUsersMessaged?.Split(",") ?? new List<int>();
        }
    
        public void Add(int i)
        {
             this.underlyingList.Add(i);
             this.entity.DbUsersMessaged  = String.Join(",", underylingList);
        }
    
        // other interface memebers impl
    }
