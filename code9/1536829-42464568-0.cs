    public static List<Car> FromTextFile(string fileName)
    {
        var lines = File.ReadAllLines(fileName);
    
        var cars = new List<Car>();
        foreach (var line in lines)
        {
            var car = FromLine(line);
            if (car == null)
                continue;
    
            cars.Add(car);
        }
    
        return cars;
    }
    
    private static Car FromLine(string line)
    {
        var values = line.Split(',');
    
        if (values.Length != 8) // There is no specification on what to do, if the amount of items is not sufficient.
            return null;
    
        // There is also no specification on what order to use, or how to map the ordering.
        return new Car
        {
            Make = values[0],
            Model = values[1],
            // There is also no specification on how to handle in-correct formats.
            // This assumes the Price property to be type of int.
            Price = int.Parse(values[2]), 
            Year = values[3],
            Colour = values[4],
            // Again; how to handle in-correct formats?
            Mileage = int.Parse(values[5]),
            Description = values[6],
            VehicleType = values[7]
        };
    }
