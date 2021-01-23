    public interface IEntityContextProvider {
       public MyDbContext CreateContext();
    }
    public class EntityContextProvider : IEntityContextProvider  {
       public MyDbContext CreateContext() {
         return new MyDbContext("ef connection string");
       }
    }
