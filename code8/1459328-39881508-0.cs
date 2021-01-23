    public class SubscaleScore
    {
        public int TestId { get; set; }
        public int Subscale { get; set; }
        public double Score { get; set; }
        public int SubscaleId { get; set; }
    
        [ForeignKey("SubscaleStatisticsId")]
        public int SubscaleStatisticsId { get; set; }
        public virtual SubscaleStatistics SubscaleStatistics { get; set; }
    
    }
