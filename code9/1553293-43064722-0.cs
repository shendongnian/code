    public class Application {
        public int ApplicationId { get; set; }
        [Required]
        public FundingInfo FundingInfo { get; set; }
        ....
    }
    public class FundingInfo {
        public long FundingInfoId { get; set; }
        ....
    }
