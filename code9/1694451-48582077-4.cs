    public class Entity {
        string domain = "DESKTOP-I4VK2LV";
        string userName = "AP-502";
        string password = "pass";
    }
    public class DataAccessLayer{
       DbContext context=new DbContext();
       public void InsertIntoDB(Object JsonRequestData)
       {  
          //Save json object to Entity poco
          context.Entity.Add(JsonRequestData);
          context.SaveChanges();
       }
            
            //Other CRUD stuff
    }
   
