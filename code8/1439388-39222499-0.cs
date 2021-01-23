    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    public class AddressComponent
       {
           public string long_name { get; set; }
           public string short_name { get; set; }
           public List<string> types { get; set; }
       }
    
       public class Location
       {
           public double lat { get; set; }
           public double lng { get; set; }
       }
    
       public class Northeast
       {
           public double lat { get; set; }
           public double lng { get; set; }
       }
    
       public class Southwest
       {
           public double lat { get; set; }
           public double lng { get; set; }
       }
    
       public class Viewport
       {
           public Northeast northeast { get; set; }
           public Southwest southwest { get; set; }
       }
    
       public class Northeast2
       {
           public double lat { get; set; }
           public double lng { get; set; }
       }
    
       public class Southwest2
       {
           public double lat { get; set; }
           public double lng { get; set; }
       }
    
       public class Bounds
       {
           public Northeast2 northeast { get; set; }
           public Southwest2 southwest { get; set; }
       }
    
       public class Geometry
       {
           public Location location { get; set; }
           public string location_type { get; set; }
           public Viewport viewport { get; set; }
           public Bounds bounds { get; set; }
       }
    
       public class Result
       {
           public List<AddressComponent> address_components { get; set; }
           public string formatted_address { get; set; }
           public Geometry geometry { get; set; }
           public string place_id { get; set; }
           public List<string> types { get; set; }
       }
    
       public class GeoCodingModel
       {
           public List<Result> results { get; set; }
           public string status { get; set; }
       }
    
    public class Program
    {
        static public void Main()
        {
            string j = "{ \"results\" : [ { \"address_components\" : [ { \"long_name\" : \"Tower A, Spaze iTech Park\", \"short_name\" : \"Tower A, Spaze iTech Park\", \"types\" : [ \"premise\" ] }, { \"long_name\" : \"Sohna - Gurgaon Road\", \"short_name\" : \"Sohna - Gurgaon Rd\", \"types\" : [ \"route\" ] }, { \"long_name\" : \"Block S\", \"short_name\" : \"Block S\", \"types\" : [ \"political\", \"sublocality\", \"sublocality_level_3\" ] }, { \"long_name\" : \"Sector 49\", \"short_name\" : \"Sector 49\", \"types\" : [ \"political\", \"sublocality\", \"sublocality_level_1\" ] }, { \"long_name\" : \"Gurgaon\", \"short_name\" : \"Gurgaon\", \"types\" : [ \"locality\", \"political\" ] }, { \"long_name\" : \"Gurgaon\", \"short_name\" : \"Gurgaon\", \"types\" : [ \"administrative_area_level_2\", \"political\" ] }, { \"long_name\" : \"Haryana\", \"short_name\" : \"HR\", \"types\" : [ \"administrative_area_level_1\", \"political\" ] }, { \"long_name\" : \"India\", \"short_name\" : \"IN\", \"types\" : [ \"country\", \"political\" ] }, { \"long_name\" : \"122018\", \"short_name\" : \"122018\", \"types\" : [ \"postal_code\" ] } ], \"formatted_address\" : \"Tower A, Spaze iTech Park, Sohna - Gurgaon Rd, Block S, Sector 49, Gurgaon, Haryana 122018, India\", \"geometry\" : { \"location\" : { \"lat\" : 28.4138566, \"lng\" : 77.04217849999999 }, \"location_type\" : \"ROOFTOP\", \"viewport\" : { \"northeast\" : { \"lat\" : 28.4152055802915, \"lng\" : 77.0435274802915 }, \"southwest\" : { \"lat\" : 28.4125076197085, \"lng\" : 77.04082951970848 } } }, \"place_id\" : \"ChIJq9P3-JoiDTkRzBq_Q6Ala_A\", \"types\" : [ \"premise\" ] }, ], \"status\" : \"OK\" }";
    		
    		
    		
    		GeoCodingModel ro = JsonConvert.DeserializeObject<GeoCodingModel>(j);
    		
    		Console.WriteLine(ro.results[0].geometry.location_type);
    				
        }
    
    }
