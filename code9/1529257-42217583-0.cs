    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CustomerMarketingCampaign> CustomerMarketingCampaigns { get; set; }
    }
    public class CustomerMarketingCampaign
    {
        
        public int ID { get; set; }
        [Index("IX_CustomerAndMarketing", 1, IsUnique = true)]
        public int CustomerID { get; set; }
        [Index("IX_CustomerAndMarketing", 2, IsUnique = true)]
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
    }
