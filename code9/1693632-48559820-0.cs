    public class CombineController : TableController<Combine>
    {
     ...
      public IQueryable<Ancestor> GetAllAncestor()
      {
    return Query(); 
     }
    ... 
     }
