    public class ResponseData 
    { 
        public Main main { get; set; } 
        public List<Weather> weather { get; set; } // This is a List<T> of Weather
    }                                              // It can contain more than one entry 
                                                   // for weather
    public class Main 
    { 
        public double temp { get; set; } // This is a double
    } 
    public class Weather 
    { 
        public string description { get; set; }
    }
