        public class CustomUrl
    {
        public string State {get;set;}
        public string Country { get;set;}
        public string Geolocation {get;set;}
        public string City {get;set;}
    
        public ovveride string ToString()
        {
            retrun string.Format("state={0}&country={1}&geolocation={2}&city={3}",State,Country,Geolocation,City);      
        }
    }
