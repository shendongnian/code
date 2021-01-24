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
    
        // now copy the common properties
        t.MyProperty = v.MyProperty;
        t.AnotherProperty = v.AnotherProperty;
    
        return t;
    }
    public Vehicle CloneVehicle (Vehicle v)
    {
        var newVehicl = CloneBaseVehicle();
        switch(v.Type)
        {
            case(Vehicles.Tractor):
                var tractor = newVehicle as Tractor;
                tractor.TractorCapacity  = 50 ;
                break;
            case Car:
                ...
                break;
        }
        return newVehicle;
    }
