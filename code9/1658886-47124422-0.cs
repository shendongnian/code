    public interface IDbContext{}
    public class ContextA : IDbContext{}
    public class ContextB : IDbContext{}
    
    public class A
    {
          protected IDbcontext DB { get; set; }
          public A(IDbcontext db)
          {
               DB = db;
          }
    }
    public class B : A
    {
          public B():this(new ContextB(){}
          public B(IDbcontext db):base(db){}
    }
