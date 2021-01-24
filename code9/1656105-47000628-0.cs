    public class VehicleServiceFactory
    {
    	public S GetVehicleService<T, S>(T vehicle)
    		where T : Vehicle
    		where S : IVehicleService<T>, new()
    	{
    		return new S();
    	}
    }
