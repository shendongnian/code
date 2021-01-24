         //base class for table  
         public class Entity
         {
           [PrimaryKey, AutoIncrement]
           public int Id { get; set; }
         }  
         //your table
         public class Data :Entity
         {
            public string Prop1 {get;set;}  
            ......   
         }
          
         public class Data2 :Entity
         {
            public string Prop2 {get;set;}  
            ......   
         } 
