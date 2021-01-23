    public class Fuel
    {
        private string sFuelname = default(string);
        private float Price = default(float);
        
        public string FuelName
        {
            get { return sFuelName; } set { sFuelName = value; }
        }
        public float FuelPrice
        {
            get { return fFuelPrice; } set { fFuelPrice= value; }
        }
    public static class FuelsList
    {
        public Fuel LPG
        {
            get
            {
                var temp = new Fuel
                {
                    FuelName = "LPG",
                    FuelPrice = 0.65f
                }
                return temp;
            }
        }
        public Fuel Diesel
        {
            get
            {
                var temp = new Fuel
                {
                    FuelName = "Diesel",
                    FuelPrice = 0.95f
                }
                return temp;
            }
        }
        public Fuel Petrol
        {
            get
            {
                var temp = new Fuel
                {
                    FuelName = "Petrol",
                    FuelPrice = 1.15f
                }
                return temp;
            }
        }
    }
