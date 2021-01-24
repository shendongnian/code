    var car = new Car
    {
        Make = "Ford",
        Model = "Fiesta",
        Price = 10000,
        Year = "1999",
        Colour = "Red",
        Mileage = 40000,
        Description = "Lovely red car, 4 wheel, optional steering wheel.",
        VehicleType = "Car"
    };
    
    var serializer = new XmlSerializer(typeof(Car));
    
    // http://stackoverflow.com/questions/2434534/serialize-an-object-to-string
    using (StringWriter textWriter = new StringWriter())
    {
        serializer.Serialize(textWriter, car);
        var output = textWriter.ToString();
    }
