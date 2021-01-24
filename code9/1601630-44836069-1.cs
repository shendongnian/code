    abstract class Vehicle
    {
        public virtual void MethodSlot1_StartEngine() { }
    
        public virtual void MethodSlot2_StopEngine() { }
    }
    
    class Car : Vehicle
    {
        public virtual void MethodSlot3_OpenGasTank() { }
    }
    
    class NuclearSubmarine : Vehicle
    {
        public virtual void MethodSlot3_FireAllNuclearMissiles() { }
    }
    
    class VehicleUser
    {
        public delegate void OpenGasTankMethod(Car car);
    
        public void OpenGasTank(Vehicle vehicle, OpenGasTankMethod method)
        {
            //it's stopping you here from firing all nuclear weapons
            //by mistaking your car's gas tank for the armageddon switch
            method(vehicle); 
        }
    }
