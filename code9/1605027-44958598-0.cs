    public abstract class BaseFactory
    {
        protected static dbModelContainer context = new dbModelContainer();
    
        public static int UpdateDataBase_static()
        {
            return context.SaveChanges();
        }
     }
    
    public abstract class BaseFactory<T>:BaseFactory where T: class
    {
        ....
    }
