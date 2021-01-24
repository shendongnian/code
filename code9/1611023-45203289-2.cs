    public class OrderController : IOrderController
    {
      private readonly IOrderRepository _repository = null;
      private readonly IUnitOfWorkFactory _uowFactory = null;
    
      public OrderController(IUnitOfWorkFactory uowFactory, IOrderRepository repository)
      {
        if (uowFactory == null)
          throw new ArgumentNullException("uowFactory");
    
        if (repository == null)
          throw new ArgumentNullException("repository");
    
        _uowFactory = uowFactory;
        _repository = repository;
      }
    
      public void SomeActionOnOrder(int orderId)
      {
        using (var unitOfWork = _uowFactory.Create())
        {
          var order = _repository.GetOrderById(orderId)
          // Here lies your validation checks that the order was found, 
          // business logic to do your behaviour.. This is the stuff you want to test..
          // ...
    
          unitOfWork.Commit();
        }
      }
    }
