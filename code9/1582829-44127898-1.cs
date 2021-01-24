         //base class for table  
         public class Entity
         {
           [PrimaryKey, AutoIncrement]
           public int Id { get; set; }
         }  
         //your table
         public class Data :Entity
         {
            prop string FirstName {get;set;}  
         }
