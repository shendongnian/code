    public class MyViewModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int SalesOrderID { get; set; }
        public int? FKCustomerID { get; set; }
        public int SalesOrderDetailID { get; set; }
        public double? SalesOrderUnitPrice { get; set; }
        public double? SalesOrderTotal { get; set; }
        public int? FKSalesOrderID { get; set; }
        public int? FKProductID { get; set; }
    }
