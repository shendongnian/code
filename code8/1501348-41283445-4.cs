    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
    
    // Get the appSettings section.
    var carSettings = (CarSection)config.GetSection("CarMapping");
    
    //Get the settings collection (key / value pairs).
    foreach (CarElement car in carSettings.Cars)
    {
    
        Console.WriteLine("{0} - {1} ", car.BrandNumber, car.Car);
    }
