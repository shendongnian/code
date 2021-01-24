    public class PayerController : EntityController<IPayerManager>
    {
       public PayerController(IPayerManager manager) : base(manager) { }
    }
    
    public class BusinessController : EntityController<IBusinessManager>
    {
       public BusinessController(IBusinessManager manager) : base(manager) { }
    }
