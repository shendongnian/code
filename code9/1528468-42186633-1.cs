    public class CarViewResult
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Gear { get; set; }
        public CarViewResult(string manufacturer, string model, string gear)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Gear = gear;
        }
    }
