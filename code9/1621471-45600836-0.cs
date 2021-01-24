    public class Main
        {
            public double temp { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public double pressure { get; set; }
            public double sea_level { get; set; }
            public double grnd_level { get; set; }
            public int humidity { get; set; }
            public double temp_kf { get; set; }
        }
    
        public class Weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }
    
        public class Clouds
        {
            public int all { get; set; }
        }
    
        public class Wind
        {
            public double speed { get; set; }
            public double deg { get; set; }
        }
    
        public class Sys
        {
            public string pod { get; set; }
        }
    
        public class List
        {
            public int dt { get; set; }
            public Main main { get; set; }
            public IList<Weather> weather { get; set; }
            public Clouds clouds { get; set; }
            public Wind wind { get; set; }
            public Sys sys { get; set; }
            public string dt_txt { get; set; }
        }
    
        public class Coord
        {
            public double lat { get; set; }
            public double lon { get; set; }
        }
    
        public class City
        {
            public int id { get; set; }
            public string name { get; set; }
            public Coord coord { get; set; }
            public string country { get; set; }
        }
    
        public class Example
        {
            public string cod { get; set; }
            public double message { get; set; }
            public int cnt { get; set; }
            public IList<List> list { get; set; }
            public City city { get; set; }
        }
