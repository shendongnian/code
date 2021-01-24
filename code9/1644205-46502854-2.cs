    public class Test
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public int DoubleNumber { get { return 2* this.Number; } } //completely remove setter
    }
