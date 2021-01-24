    public class ItemDatabase
    {
       private static ItemDatabase _instance;
       private static readonly object _lock = new object();
    
       private ItemDatabase() {}
    
       public static ItemDatabase Instance
       {
          get 
          {
             lock (_object)
             {
                 if (instance == null)
                 {
                    instance = new ItemDatabase();
                 }
                 return instance;
             }
          }
       }
       // ... add the rest of your code
    }
