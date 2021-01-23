    Car.GetCar(CallThisMethod);
    // See the signature of this method: it takes a string and returns IVehicle
    public static IVehicle CallThisMethod(string someString)
    {
        return new Car();
    }
