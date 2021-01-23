    public class NRCSSoilInput
    {
        public class BBox
        {
            public double north { get; set; }
            public double south { get; set; }
            [Required]
            public double east { get; set; }
            [Required]
            [DoubleGreaterThan("east")]
            public double west { get; set; }
        }
        public BBox box { get; set; }
    }
