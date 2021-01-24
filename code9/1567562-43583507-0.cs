    class Car
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public CarManufacturer Manufacturer { get; set; }
    }
    
    Car car = new Car();
    car.Name = "Corvette";
    car.Color = Color.Yellow;
    car.Manufacturer = new CarManufacturer();
    car.Manufacturer.Name = "Chevrolet";
    car.Manufacturer.Country = "USA";
