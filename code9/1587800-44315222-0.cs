    public class Account
    {
        [Key, Column(Order = 0)]
        public string SrcSys { get; set; }
        [Key, Column(Order = 1)]
        public string CustId { get; set; }
        [Key, Column(Order = 2)]
        public string AccId { get; set; }
        public string BrId { get; set; }
        public string ProdId { get; set; }
        public virtual ICollection<Balance> Balances { get; set; }
        [ForeignKey("SrcSys,CustId")] // <= the composite FK
        public virtual Customer Customers { get; set; }
    }
