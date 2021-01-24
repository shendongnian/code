    var car = new Car
    {
        Make = "Honda",
        Model = "Civic",
        Year = "1997"
    };
    var builder = new StringBuilder();
    foreach (PropertyInfo info in car.GetType().GetProperties())
    {
        if (builder.Length > 0)
        {
            builder.Append(", ");
        }
        var value = info.GetValue(car, null) ?? "null";
        builder.Append(info.Name);
        builder.Append(" = ");
        builder.Append(value);
    }
    Console.WriteLine(builder.ToString()); // "Make = Honda, Model = Civic, Year = 1997"
