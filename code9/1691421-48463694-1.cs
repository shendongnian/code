    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserIsActiveCode { get; set; }
        [ForeignKey("UserIsActiveCode")]
        public YesNo UserIsActive { get; set; }
    }
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductIsOnDiscountCode { get; set; }
        [ForeignKey("ProductIsOnDiscountCode")]
        public YesNo ProductIsOnDiscount { get; set; }
    }
