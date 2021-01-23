    public class order
    {
        public int id { get; set; }    
        public virtual IList<OrderProducts> OrderProducts { get; set; }
    }
    //...
    public IEnumerable<Order> GetAll()
    {
        return dataContext.Orders
                          .Include(order => order.OrderProducts)
                          .ThenInclude(orderProducts => orderProducts.Product);
    }
