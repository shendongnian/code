    public class Planet
    {
        private static string PlanetName;
        private static double PlanetMass;
        private static double PlanetDistance;
        public Planet(string name)
        {
            PlanetName = name;
        }
        
        public void SetPlanetName(string name)
        {
            PlanetName = name;
        }
        public string GetPlanetName()
        {
            return PlanetName;
        }
        public void SetPlanetMass(double mass)
        {
            PlanetMass = mass;
        }
        public double GetPlanetMass()
        {
            return PlanetMass;
        }
        public void SetPlanetDistance(double distance)
        {
            PlanetDistance = distance;
        }
        public double GetPlanetDistance()
        {
            return PlanetDistance;
        }
    }
