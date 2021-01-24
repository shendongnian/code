    public static void Initialize(Car vehicle)
    {
        vehicle.Length = 5.00; //if vehicle is a Car (not derivated) will be 5 if it's a truck will not set
        vehicle.MaxSpeed = 350; //will set to 350 for both, even if Truck does not allow over 100, the method called is on the car Class, not Truck
    }
    
    Initialize(new Car());
    Initialize(new Truck()); //Length won't pass (as intended on Truck class to only allow higher than 20) but MaxSpeed will pass as 350, even if Truck does not allow it
