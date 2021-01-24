    public static IQueryable<Cargo> ReadyToCarry(this IQueryable<Cargo> q, bool ready = true)
    {
        VehicleType[] dontNeedCouple = new VehicleType[] { VehicleType.Sprinter, VehicleType.Van, VehicleType.Truck };
        var readyToCarry = q.Where(c => c.DriverId > 0 && c.VehicleId > 0)
                            .Where(c => c.CoupleId > 0 || dontNeedCouple.Contains(c.Vehicle.Type));
    
        if (ready)
        {
            return readyToCarry;
        }
        else
        {
            return q.Except(readyToCarry);
        }
    }
