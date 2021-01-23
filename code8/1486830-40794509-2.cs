    class Program
    {
        public static List<Car> CarList;
        static void Main(string[] args)
        {
            PopulateCars();
            int car, length;
            decimal rate = 0m;
            Car.CarBand band;
            Console.WriteLine("{0,-12} {1,-12} {2,-12}", "Diesel Car", "Petrol Car", "Alt. Fuel Car");
            Console.WriteLine("{0,-12} {1,-12} {2,-12}", "TC 49", "TC 48", "TC 59");
            Console.WriteLine("Enter Car Type (TC #): ");
            var keyboardInput = Console.ReadLine();
            while (!int.TryParse(keyboardInput, out car))
            {
                Console.WriteLine("Invalid car input, try again.");
                keyboardInput = Console.ReadLine();
            }
            Console.WriteLine("Enter Licience length in months(6 or 12)");
            keyboardInput = Console.ReadLine();
            while (!int.TryParse(keyboardInput, out length))
            {
                Console.WriteLine("Invalid months input, try again.");
                keyboardInput = Console.ReadLine();
            }
            Console.WriteLine("Enter Emission Band (AA, A, B, C, D): ");
            keyboardInput = Console.ReadLine();
            while (!Enum.TryParse(keyboardInput, out band))
            {
                Console.WriteLine("Invalid band input, try again.");
                keyboardInput = Console.ReadLine();
            }
            var matchedCar = CarList.FirstOrDefault(c => c.CarNumber == car && c.Lenght == length && c.Band == band);
            if (matchedCar != null)
                Console.WriteLine("The rate for this car is {0}", matchedCar.Rate);
            else
                Console.WriteLine("Car not found");
            Console.ReadLine();
        }
        public class Car
        {
            public int CarNumber { get; set; }
            public int Lenght { get; set; }
            public CarBand Band { get; set; }
            public decimal Rate { get; set; }
            public enum CarBand
            {
                AA,
                A,
                B,
                C,
                D
            }
        }
       
        public static void PopulateCars()
        {
            CarList = new List<Car>();
            // Cars 48
            CarList.Add(new Car { CarNumber = 48, Lenght = 6, Band = Car.CarBand.AA, Rate = 38.5m });
            CarList.Add(new Car { CarNumber = 48, Lenght = 6, Band = Car.CarBand.A, Rate = 55m });
            CarList.Add(new Car { CarNumber = 48, Lenght = 6, Band = Car.CarBand.B, Rate = 66m });
            CarList.Add(new Car { CarNumber = 48, Lenght = 6, Band = Car.CarBand.C, Rate = 77m });
            CarList.Add(new Car { CarNumber = 48, Lenght = 6, Band = Car.CarBand.D, Rate = 85.25m });
            CarList.Add(new Car { CarNumber = 48, Lenght = 12, Band = Car.CarBand.AA, Rate = 70m });
            CarList.Add(new Car { CarNumber = 48, Lenght = 12, Band = Car.CarBand.A, Rate = 100m });
            CarList.Add(new Car { CarNumber = 48, Lenght = 12, Band = Car.CarBand.B, Rate = 120m });
            CarList.Add(new Car { CarNumber = 48, Lenght = 12, Band = Car.CarBand.C, Rate = 140m });
            CarList.Add(new Car { CarNumber = 48, Lenght = 12, Band = Car.CarBand.D, Rate = 155m });
            //Cars 49
            CarList.Add(new Car { CarNumber = 49, Lenght = 6, Band = Car.CarBand.AA, Rate = 44m });
            CarList.Add(new Car { CarNumber = 49, Lenght = 6, Band = Car.CarBand.A, Rate = 60.5m });
            CarList.Add(new Car { CarNumber = 49, Lenght = 6, Band = Car.CarBand.B, Rate = 71.5m });
            CarList.Add(new Car { CarNumber = 49, Lenght = 6, Band = Car.CarBand.C, Rate = 82.5m });
            CarList.Add(new Car { CarNumber = 49, Lenght = 6, Band = Car.CarBand.D, Rate = 88m });
            CarList.Add(new Car { CarNumber = 49, Lenght = 12, Band = Car.CarBand.AA, Rate = 80m });
            CarList.Add(new Car { CarNumber = 49, Lenght = 12, Band = Car.CarBand.A, Rate = 110m });
            CarList.Add(new Car { CarNumber = 49, Lenght = 12, Band = Car.CarBand.B, Rate = 130m});
            CarList.Add(new Car { CarNumber = 49, Lenght = 12, Band = Car.CarBand.C, Rate = 150m });
            CarList.Add(new Car { CarNumber = 49, Lenght = 12, Band = Car.CarBand.D, Rate = 160m });           
            // Cars 59
            CarList.Add(new Car { CarNumber = 59, Lenght = 6, Band = Car.CarBand.AA, Rate = 33m });
            CarList.Add(new Car { CarNumber = 59, Lenght = 6, Band = Car.CarBand.A, Rate = 49.5m });
            CarList.Add(new Car { CarNumber = 59, Lenght = 6, Band = Car.CarBand.B, Rate = 60.5m });
            CarList.Add(new Car { CarNumber = 59, Lenght = 6, Band = Car.CarBand.C, Rate = 71.5m });
            CarList.Add(new Car { CarNumber = 59, Lenght = 6, Band = Car.CarBand.D, Rate = 82.5m });
            CarList.Add(new Car { CarNumber = 59, Lenght = 12, Band = Car.CarBand.AA, Rate = 60m });
            CarList.Add(new Car { CarNumber = 59, Lenght = 12, Band = Car.CarBand.A, Rate = 90m });
            CarList.Add(new Car { CarNumber = 59, Lenght = 12, Band = Car.CarBand.B, Rate = 110m });
            CarList.Add(new Car { CarNumber = 59, Lenght = 12, Band = Car.CarBand.C, Rate = 130m });
            CarList.Add(new Car { CarNumber = 59, Lenght = 12, Band = Car.CarBand.D, Rate = 150m });        
        }
    }
