    public abstract class BaseTransport<T> where T : BaseProperties
    {
        public abstract T Properties();
    }
    
    public class Car : BaseTransport<CarProperties>
    {
        public override CarProperties Properties()
        {
           return new CarProperties();
        }
    }
    
    public class Bike : BaseTransport<BikeProperties>
    {
        public override BikeProperties Properties()
        {
           return new BikeProperties();
        }
    }
