    public class Customer
    {   
        public int CustomerId { get; set; }
    
        public virtual ICollection<CustomerMarketingCampaign> CustomerMarketingCampaign { get; set; }
    
    }
    
    public class CustomerMarketingCampaign
    {   
        [ForeignKey("Customer")]
        public int CustomerMarketingCampaignId
        [ForeignKey("Campaign")]
        public int CampaignId { get; set; }
    
    }
    public class Campaign
    {
        public int CampaignId {get;set;}
        public string Name {get;set;}
    } 
