    public class Coord
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }
        [JsonProperty("lat")]
        public double Lat { get; set; }
    }
    public class Sys
    {
        [JsonProperty("type")]
        public int Type { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("message")]
        public double Message { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }
        [JsonProperty("sunset")]
        public int Sunset { get; set; }
    }
    public class Weather
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("main")]
        public string Main { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
    public class Main
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }
        [JsonProperty("pressure")]
        public int Pressure { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
        [JsonProperty("temp_min")]
        public double TempMin { get; set; }
        [JsonProperty("temp_max")]
        public double TempMax { get; set; }
    }
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
        [JsonProperty("deg")]
        public int Deg { get; set; }
    }
    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
    public class List
    {
        [JsonProperty("coord")]
        public Coord Coord { get; set; }
        [JsonProperty("sys")]
        public Sys Sys { get; set; }
        [JsonProperty("weather")]
        public IList<Weather> Weather { get; set; }
        [JsonProperty("main")]
        public Main Main { get; set; }
        [JsonProperty("visibility")]
        public int Visibility { get; set; }
        [JsonProperty("wind")]
        public Wind Wind { get; set; }
        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }
        [JsonProperty("dt")]
        public int Dt { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
    public class Example
    {
        [JsonProperty("cnt")]
        public int Cnt { get; set; }
        [JsonProperty("list")]
        public IList<List> List { get; set; }
    }
