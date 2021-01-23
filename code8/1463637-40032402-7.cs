    // the root
    [XmlRoot("weatherdata")]
    public class WeatherData
    {
        [XmlElement("product")] 
        public Product Product {get; set;}
    }
    
    public class Product
    {
        [XmlElement("time")] 
        public List<Time> ForeCasts {get;set;}
    }
    
    public class Time
    {
       [XmlAttribute("from")]
       public DateTime From {get;set;}
       [XmlAttribute("to")]
       public DateTime To {get;set;}
       [XmlElement("location")]
       public Location Location{get;set;}
    }
    
    
    public class Location 
    {
       [XmlAttribute("altitude")]
       public string Altitude {get;set;}
       [XmlElement("temperature")]
       public Value Temperature {get;set;}
       [XmlElement("windDirection")]
       public Measurement WindDirection {get;set;} 
       [XmlElement("pressure")]
       public Measurement Pressure {get;set;}
       [XmlElement("fog")]
       public Percent Fog {get;set;}
       // add the rest
    }
    
