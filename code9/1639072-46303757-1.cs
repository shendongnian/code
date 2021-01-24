    public class ItemDatabase
    {
       private static ItemDatabase _instance;
    
       private ItemDatabase() {}
    
       public static ItemDatabase Instance
       {
          get 
          {
             if (instance == null)
             {
                instance = new ItemDatabase();
             }
             return instance;
          }
       }
       // ... add the rest of your code
    }
