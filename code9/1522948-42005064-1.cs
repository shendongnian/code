            var mustang = new Car
            {
                Brand = "Ford",
                Model = "Mustang",
                Price = 30000.00M
            };
            var focus = new Car
            {
                Brand = "Ford",
                Model = "Focus",
                Price = 20000.00M
            };
            var corvette = new Car
            {
                Brand = "GM",
                Model = "Corvette",
                Price = 50000.00M
            };
            CarView dealerCars = new CarView()
            {
                CarList = new List<Car>()
            };           
            dealerCars.CarList.Add(mustang);
            dealerCars.CarList.Add(focus);
            dealerCars.CarList.Add(corvette);
            var filteredList = dealerCars.CarList.Where(item => item.Brand == "Ford");
                     
            foreach(var car in filteredList)
            {
                Console.WriteLine("Brand: {0}, Model: {1}, Price: ${2}", car.Brand, car.Model, car.Price);                
            }
            Console.ReadLine();
