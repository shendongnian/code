    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CustomerMarketingCampaign> CustomerMarketingCampaigns { get; set; }
    }
    public class MarketingAction
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class CustomerMarketingCampaign
    {
        public int ID { get; set; }
        [Index("IX_CustomerAndMarketing", 1, IsUnique = true)]
        public int CustomerID { get; set; }
        [Index("IX_CustomerAndMarketing", 2, IsUnique = true)]
        public int MarketingActionID { get; set; }
        
        // I also have several properties not included for tracking the progress of the campaign
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("MarketingActionID")]
        public virtual MarketingAction MarketingAction { get; set; }
    }
