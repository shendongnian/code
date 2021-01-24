    struct SSales
    {
        public int Year { get; private set; }
        public double Sales { get; private set; } // This should REALLY be decimal type
        public SSales(int year, double sales) : this()
        {
            Year = year;
            Sales = sales;
        }
        public override string ToString()
        {
            return string.Format("{0}    ${1:F2}", Year, Sales);
        }
    }
