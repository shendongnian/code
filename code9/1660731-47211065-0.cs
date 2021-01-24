    public class unitofWork(){
    
       private YourDBContext_dbContext = new YourDBContext_dbContext(); 
    
       public OrderItemRepository OrderItemRepository
       { 
         get
         {
           return _orderItemRepository ?? (_orderItemRepository = new OrderItemRepository(_dbContext));
         }
       }
    
       public void Save()
       {
                //your save logic save changes you want
                _dbContext.SaveChanges(); 
       }    
    }
