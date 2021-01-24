    public class PayerController
    {
        private IPayerManager _entityManager{get;}
        public PayerController(IPayerManager entityManager)
       {
           _entityManager= entityManager;
       }
    }
    public class BusinessController
    {
        private IBusinessManager _entityManager{get;}
        public BusinessController(IBusinessManager entityManager)
       {
           _entityManager= entityManager;
       }
    }
