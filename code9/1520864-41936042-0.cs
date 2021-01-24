    class Program
    {
        static void Main()
        {
            foreach(var field in typeof(Order).GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
            {
                Console.WriteLine(field.Name);
            }
        }
        
        public class Order
        {
            public int OrderID { get; set; }
            public int EmployeeID { get; set; }
            public string CustomerID { get; set; }
            public DateTime OrderDate { get; set; }
            public bool Verified { get; set; }
    
            public Order(int orderId, int empId, string custId, DateTime orderDate, bool verify)
            {
                this.OrderID = orderId;
                this.EmployeeID = empId;
                this.CustomerID = custId;
                this.OrderDate = orderDate;
                this.Verified = verify;
            }
        }
    }
