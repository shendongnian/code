    public abstract class BaseEntity<T>  
    {  
      public T Id { get; private set; }  
    }
    public class Product : BaseEntitiy<int> 
    {
      //do stuff
    }
