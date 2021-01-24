    Vehicle CloneBaseVehicle(Vehicle v)
    {
        Tractor t;
        switch v.Type
        {
            case Vehicles.Tractor:
                t = new Tractor();
            case Vehicles.Car:
                t = new Car();
            case Vehicles.Motorcycle:
                t = new Motorcycle();
        }
    
        var properties = typeof(Vehicle).GetProperties();
        foreach(var p in properties)
            p.SetValue(t, v.GetValue(p));
    
        return t;
    }
