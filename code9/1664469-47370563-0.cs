    public class Car
    {
        [HiddenInput(DisplayValue = false)]
        public int CarID { get; set; }
        public string ModelName { get; set; }
        public int ManufacturerID { get; set; }
        public int Year { get; set; }
        public decimal Mpg { get; set; }
    }
