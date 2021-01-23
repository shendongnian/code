    protected override void Seed(CarContext context)
        {
            var cars = new List<Car>
            {
                new Car { Id=1033, Model="Corolla", Mark="Toyota", hasAC=true, rentalCost=65 }
            };
            cars.ForEach(ca => context.Cars.Add(ca));
            var customers = new List<Customer>
            {
                new Customer {Car = cars.First(), FirstName="Carson", LastName="Alexander", Address="183 Court Road", ZipCode="T7D 0C1", City="Toronto", rentStart = DateTime.Now, rentEnd = DateTime.Now },
                new Customer {Car = cars.First(), FirstName="Meredith", LastName="Alonso", Address="101 Baseline Rd", ZipCode="V4D 0G2", City="Vancouver", rentStart = DateTime.Now, rentEnd = DateTime.Now },
                new Customer {Car = cars.First(), FirstName="Arturo", LastName="Brand", Address="1043 34st", ZipCode="T5Z 3P1", City="Calgary", rentStart = DateTime.Now, rentEnd = DateTime.Now }
            };
            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();
        }
