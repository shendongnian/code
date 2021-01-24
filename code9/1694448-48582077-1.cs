    namespace CreateEntityConsole
    {
       public class Entity
       {
           private DbContext context;
           public Entity()
           {
              context = new DbContext();
           }
           public void InsertIntoDB(Object JsonRequestData)
           {  
              context.Entity.Add(JsonRequestData);
              context.SaveChanges();
           }
            
            //Other CRUD stuff
      }
    }
