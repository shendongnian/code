    public class PortfolioHolding
        {
            public string fundIdentifier { get; set; }
            public int fundRating { get; set; }
            public double fundExpenseRatio { get; set; }
            public double fundWeight { get; set; }
            [JsonIgnore]
            public double fundAlpha { get; set; } //MODIFIED by adding fundAlpha attribute
        }
