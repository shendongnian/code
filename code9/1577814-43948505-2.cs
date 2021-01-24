    public class Dto
    {
        [IgnoreDataMember]
        public decimal Decimal { get; set; }
        public string DecimalFormat => Decimal.ToString("0.##");
    }
