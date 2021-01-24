    public class CustomIdentityService
    {
       protected MyContext _context = new MyContext();
               
       public Guid FooInfo(Guid IdentityUserID)
       {
        return con.fooTable.Where(x => x.IdentityUserID == IdentityUserID).
        Select(us => new { us.fooData }).FirstOrDefault().fooData;
       }
     }
