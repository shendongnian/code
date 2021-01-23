    class ResponseData 
    { 
        public Main main; 
        public List<Weather> weather; // This is a List<T> of Weather
    }                                 // It can contain more than one entry for weather
    class Main 
    { 
        public double temp; // This is a double
    } 
    class Weather 
    { 
        public string description; 
    }
