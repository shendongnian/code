    public class CombineController : TableController<Combine>
    {
     ...
      public IQueryable<Combine> GetAllAncestor()
      {
    return Query(); 
     }
    ... 
     }
