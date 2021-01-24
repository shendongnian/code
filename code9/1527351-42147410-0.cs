    //Get the price of the vehicle with parameter ID.
    public double getPriceVehicle(int iD)
    {
        if (iD >= 0 && iD < vehicleList.Count)
        {
            foreach (Vehicle vehicle in vehicleList)
            {
                if (vehicle.iD == iD) return vehicle.price;
            }
        }
        return 0;
    }
