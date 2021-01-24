    public class Employee
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public double Rate { get; set; }
        public double Hours { get; set; }
        public override string ToString()
        {
            return $"{Name.PadRight(20)} {Number} {Rate:00.00} {Hours:00.00}";
        }
    }
