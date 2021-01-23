    To set the navigation properties"
    
        public class InvestorViewModel
        {
            public int InvestorId { get; set; }
            public string InvestorName { get; set; }
            public DateTime FundingDate { get; set; }
            public DateTime? DueDate { get; set; }
            public Decimal? FundsCommitted { get; set; }
            public Decimal? FundsInvested { get; set; }
            public virtual ICollection<InvestorStatementLineVM>  StatementLines { get; set; }
        }
