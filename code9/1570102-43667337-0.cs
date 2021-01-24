    void Main()
    {
        var testData = "http://samples.openweathermap.org/data/2.5/forecast?q=Washington&appid=...";
        var json = new WebClient().DownloadString(testData);
        var result = JsonConvert.DeserializeObject<RootObject>(json);
        
        Console.WriteLine("City:" + result.city.name);
        Console.WriteLine();
            
        const double AbsoluteZero = -273.15;
        foreach (var forecast in result.list)
        {
            Console.WriteLine("{0:ddd hh:MM}: {1:f2}c ~ {2:f2}c ~ {3:f2}c",
                forecast.dt,
                AbsoluteZero + forecast.main.temp, 
                AbsoluteZero + forecast.main.temp_min, 
                AbsoluteZero + forecast.main.temp_max); 
        }
    }
    
    // Define other methods and classes here
    public class MainDetail
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; }
    }
    
    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    
    public class Clouds
    {
        public int all { get; set; }
    }
    
    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }
    
    public class Rain
    {
        public double rain { get; set; }
    }
    
    public class Sys
    {
        public string pod { get; set; }
    }
    
    public class Forecast
    {
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime dt { get; set; }
        public MainDetail main { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Rain rain { get; set; }
        public Sys sys { get; set; }
        public string dt_txt { get; set; }
    }
    
    public class Coord
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }
    
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
    }
    
    public class RootObject
    {
        public string cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public List<Forecast> list { get; set; }
        public City city { get; set; }
    }
    
    public class UnixTimestampConverter : Newtonsoft.Json.JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds((long)reader.Value);
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
