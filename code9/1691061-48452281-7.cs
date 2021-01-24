    public class SampleItem
    {
        [DataType(DataType.Currency)]
        public double RealMoney { get; set; }
        public double RealValue { get; set; }
        [DataType(DataType.Currency)]
        public int IntMoney { get; set; }
        public int IntValue { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }
    }
