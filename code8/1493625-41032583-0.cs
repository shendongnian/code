    public class OrderUserVM
    {
        public int OrderNumber { get; set; }
        ...
        public string FirstName { get; set; }
        ...
    }
     public IList<OrderUserVM> OrderList { get; set; }
     OrderList = (from row in db.Orders
                             join rowjoin in db.Users on row.UserId equals rowjoin.Id
                             orderby row.OrderNumber
                             select new OrderUserVM
                             {
                                 OrderNumber = row.OrderNumber,
                                 ...
                                 FirstName = rowjoin.FirstName,
                                 ....
                             }).ToList();
