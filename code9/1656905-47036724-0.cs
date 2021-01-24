    class User
    {
        public string Name { get; set; }
        public Car[] Cars { get; set; }
    }
    class Car
    {
        public string Make { get; set; }
        public int Year { get; set; }
    }
    var user = new User
    {
        Name = "Me",
        Cars = new Car[]
        {
            new Car { Make = "Car1", Year = 2000 }, 
            new Car { Make = "Car2", Year = 2017 }
        }
    };
    var serializer = new SerializerBuilder().Build();
    var asYaml = serializer.Serialize(user);
