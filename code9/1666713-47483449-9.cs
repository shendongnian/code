    public class CarDAO
    {
        public Car[] GetCars()
        {
            var cars = 
                new Car[] {
                    new Car
                    {
                        Id = 1,
                        Model = "718 Cayman",
                        Brand = "Porsche"
                    },
                    new Car
                    {
                        Id = 2,
                        Model = "718 Boxster",
                        Brand = "Porsche"
                    },
                    new Car
                    {
                        Id = 3,
                        Model = "718 GTS",
                        Brand = "Porsche"
                    },
                    new Car
                    {
                        Id = 4,
                        Model = "911 Carrera",
                        Brand = "Porsche"
                    },
                    new Car
                    {
                        Id = 5,
                        Model = "718 GTS",
                        Brand = "Porsche"
                    },
                    new Car
                    {
                        Id = 6,
                        Model = "812 Superfast",
                        Brand = "Ferrari"
                    },
                    new Car
                    {
                        Id = 7,
                        Model = "GTC4 Lusso",
                        Brand = "Ferrari"
                    },
                    new Car
                    {
                        Id = 8,
                        Model = "488 GTB",
                        Brand = "Ferrari"
                    },
                    new Car
                    {
                        Id = 9,
                        Model = "488 Spider",
                        Brand = "Ferrari"
                    },
                    new Car
                    {
                        Id = 10,
                        Model = "LaFerrari Aperta",
                        Brand = "Ferrari"
                    }
                };
            return cars;
        }
    }
    
