    public class PayerManager : EntityManager,IPayerManager 
    {
        public void MyPayer()
        {
        }
    }
     public class BusinessManager : EntityManager,IBusinessManager 
     {
         public void MyBusiness()
         {
         }
     }
     public abstract class EntityManager
     {
         public string IAMCommon()
         {
             return "";
         }
     }
