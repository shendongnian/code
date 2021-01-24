     public IEnumarable<User> GetItems() 
     {
       IEnumarable<User> resultingList;
       using (var context = new MyDbContext()) 
       {
         IQueryable<User> a = SomeQuery(context);
         IQueryable<User> b = SomeOtherQuery(context);
         var union = a.Union(b);
         resultingList = union.Include(x => x.Role).ToList();
       }   
       return resultingList; 
     }
