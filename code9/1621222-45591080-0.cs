    public class WeatherInfo
    {
        public Coordinate coord { get; set; }
        public Weather[] weather { get; set; }
        public string base { get; set; }
        public MainInfo main { get; set; }
        public float visibility { get; set; }
        public WindInfo wind { get; set; }
        public CloudInfo clouds { get; set; }
        public long dt { get; set; }
        public SysInfo sys { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
    public class SysInfo
    {
        public int type { get; set; }
        public int id { get; set; }
        public float message { get; set; }
        public string country { get; set; }
        public long sunrise { get; set; }
        public long sunset { get; set; }
    }
    public class CloudInfo
    {
        public float all { get; set; }
    }
    public class WindInfo
    {
        public float speed { get; set; }
        public float deg { get; set; }
    }
    public class MainInfo
    {
        public float temp { get; set; }
        public float pressure { get; set; }
        public float humidity { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
    }
    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    public struct Coordinate
    {
        public float lat { get; set; }
        public float lon { get; set; }
    }
