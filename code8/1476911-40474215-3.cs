    public class CustomUrl
    {
        public string State {get;set;}
        public string Country { get;set;}
        public string Geolocation {get;set;}
        public string City {get;set;}
    
        public ovveride string ToString() =>
            $"state={State}&country={Country}&geolocation={Geolocation}&city={City}";      
        
    }
