    public static class FuelList
    {
        static FuelList()
        {
            LPG = new Fuel{ Name = "LPG", Price = .65F };
            //...
        }
        public static Fuel LPG {get;} 
        public static Fuel Diesel {get;}
        public static Fuel Petrol {get;}
    }
    public sealed class Fuel
    {
        public string Name {get;set;}
        public float Price {get;set;}
    }
