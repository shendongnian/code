    public class FeeType
    {
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public string Name { get; set; }
        public static readonly FeeType[] List = new[]
        {
            new FeeType { Min = 0, Max = 10, Name = "Type1", },
            new FeeType { Min = 2, Max = 20, Name = "Type2", },
        };
    }
