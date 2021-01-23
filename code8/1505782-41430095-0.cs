    public class Pump
    {
        private int _fuelRate;
        public Car ServicingCar { get; set; }
    
        public Pump(int fuelRate = 10)
        {
            _fuelRate = fuelRate;
        }
    
        public void IncreaseFuel()
        {
            if (ServicingCar == null) return;
    
            ServicingCar.Fuel += _fuelRate;
        }
    }
