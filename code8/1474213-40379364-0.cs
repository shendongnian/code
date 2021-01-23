    public interface ICar
    {
        bool IsSpeeds200KMPH(CarData carData);
        bool IsABSEnabled(CarData carData);
        int doors {get;set;}
        int wheels {get;set;}
        bool ABSAdvanced{get;};
        bool IsSpeedReaches225();
        void drive(CarType car);
    }
    public abstract class AbstractCar : ICar {
        public bool ABSAdvanced {
            get {
                if(!isABSEnabled()) {
                    return false;
                }
                /* some additional logic based on the interface */
                /* ... */
                return true;
            }
        }
    }
