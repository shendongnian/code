    string line = "Candy Red Riding Hood,0.17,2.21,true";
            
    var parts = line.Split(',');
    var stringValue = parts[0];
    var doubles = parts.Skip(1).Take(2)
                       .Select(x => double.Parse(x, CultureInfo.InvariantCulture))
                       .ToList();
    var boolValue = Convert.ToBoolean(parts[3]);
