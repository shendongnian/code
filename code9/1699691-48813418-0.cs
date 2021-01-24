    public class Weather
    {
        public bool? isRaining { get; set; }
        public bool? isSnowing { get; set; }
        public float? temp { get; set; }
    }
    Weather readWeather = JsonConvert.DeserializeObject<Weather>(data);
    if(readWeather.isRaining != null)
    {
        Console.WriteLine("It is " + (readWeather.isRaining.Value ? "now raining" : "no longer raining"));
    }
