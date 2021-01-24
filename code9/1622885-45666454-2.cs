    public abstract class EntityManager : IEntityManager 
    { 
        protected EntityManager() { }
    }
    
    public class PayerManager : EntityManager, IPayerManager 
    { 
        public PayerManager() : base() { }
    }
    
    public class BusinessManager : EntityManager, IBusinessManager 
    { 
        public BusinessManager() : base() { }
    }
