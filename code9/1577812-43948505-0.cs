    public class Dto
    {
        public decimal Decimal { get; set; }
        public string DecimalFormat => Decimal.ToString("0.##");
    }
