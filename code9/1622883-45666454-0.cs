    public class PayerController
    {
       private PayerManager Manager { get; }
    
       public PayerController(PayerManager manager)
       {
          Manager = manager;
       }
    }
    
    public class BusinessController
    {
       private BusinessManager Manager { get; }
    
       public BusinessController(BusinessManager manager)
       {
          Manager = manager;
       }
    }
