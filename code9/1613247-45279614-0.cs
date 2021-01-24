    public class WeatherType
    {
        private readonly string name;
        public static readonly WeatherType Bad = new WeatherType("Bad");
        public static readonly WeatherType Good = new WeatherType("Good");
        public static readonly WeatherType Mid = new WeatherType("Mid");
        private static readonly WeatherType[] Values = { Bad, Good, Mid };
        public static WeatherType[] GetValues()
        {
            return (WeatherType[])Values.Clone();
        }
        private WeatherType(string name)
        {
            this.name = name;
        }
    }
