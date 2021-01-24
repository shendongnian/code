    var carsDict = new Dictionary<string, List<Car>>()
    {
       { "Ford", new List<Car>() },
       { "GM", new List<Car>() },
    };
    var mustang = new Car
    {
        Brand = "Ford",
        Model = "Mustang",
        Price = 30000
    }
    carsDict["Ford"].Add(mustang);
