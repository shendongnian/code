    var carsDict = new Dictionary<string, List<CarDetails>>()
    {
       { "Ford", new List<CarDetails>() },
       { "GM", new List<CarDetails>() },
    };
    var mustang = new CarDetails
    {
        Brand = "Ford",
        Model = "Mustang",
        Price = 30000
    }
    carsDict["Ford"].Add(mustang);
    carsDict["Ford"].Add(new CarDetails { Brand="Ford", Model="Focus", Price=20000 });
