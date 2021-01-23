    public abstract class Vehicle 
    {
        public virtual int Wheels { get { return 4; } }
    
        public int CountWheels()
        {
            return Wheels;
        }
    }
    
    public class Motorcycle : Vehicle
    {
        public override int Wheels { get { return 2; } }
    }
