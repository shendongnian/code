    // abstract if you do not want a vehicle to exist with having a concrete definition
    public abstract class Vehicle {
    }
    public class NonWheeled : Vehicle{
    }
    public abstract class WheeledVehicle : Vehicle {
    }
    
    public class TwoWheeledVehicle : WheeledVehicle {
    }
    
    public class FourWheeledVehicle : WheeledVehicle {
    }
    
    public class ThousandWheeledVehicle : WheeledVehicle {
    }
