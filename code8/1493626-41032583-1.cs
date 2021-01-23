    public class OrderUserVM
    {
        public User User { get; set; }
        public Order Order { get; set; }
    }
    public IList<OrderUserVM> OrderList { get; set; }
    OrderList = (from row in db.Orders
                             join rowjoin in db.Users on row.UserId equals rowjoin.Id
                             orderby row.OrderNumber
                             select new OrderUserVM
                             {
                                 Order = row,
                                 User = rowjoin,
                             }).ToList();
