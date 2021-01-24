    public class OrderRepository : IOrderRepository 
    {
        private EntityFrameworkContext _context;
        ....
        public IQueryable<Order> FindBy(Expression<Func<OrderDTO, bool>> predicate)
        {
            return ConvertToDomainModel(_context.Orders.where(predicate);
        }
    }
