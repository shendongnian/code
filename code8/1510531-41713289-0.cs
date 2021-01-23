    public class MemberPaymentVM
    {
        public string MemberName{ get; set; }
        public string TransactId { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime PayDate { get; set; }
        public IEnumerable<CategoryAmountsVM> Payments { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal TotalAmount { get; set; }
    }
    public class CategoryAmountsVM
    {
        public string Category { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Amount { get; set; }
    }
