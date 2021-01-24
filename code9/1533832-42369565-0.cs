    public static IQueryable<Cargo> ReadyToCarry(this IQueryable<Cargo> q, bool ready = true)
    {
        VehicleType[] dontNeedCouple = new VehicleType[] { VehicleType.Sprinter, VehicleType.Van, VehicleType.Truck };
    
        if (ready)
        {
            return q.Where(c => c.DriverId > 0 && c.VehicleId > 0)
                    .Where(c => c.CoupleId > 0 || dontNeedCouple.Contains(c.Vehicle.Type));
        }
        else
        {
            // logic to get not ready for carrying
        }
    }
