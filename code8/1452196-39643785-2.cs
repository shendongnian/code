    public class BaseEntity
    {
         public BaseEntity()
         {
              if(Id==Guid.Empty)
                   Id = Guid.NewGuid();
         }
    
         public Guid Id{get;set;}
    }
