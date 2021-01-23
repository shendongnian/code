        namespace JSON
        {
            using Newtonsoft.Json;
            using System.Collections.Generic;
            using System.Linq;
    
            class Program
            {
                static void Main(string[] args)
                {
                    var json = "{\"Telephones\": [{ \"TapiLine\": \"XX Line\", \"SpeakerList\": [{ \"Name\": \"Office\", \"Ip\": \"192.168.10.204\", \"Volume\": \"5\" }, { \"Name\": \"Living\", \"Ip\": \"192.168.10.214\", \"Volume\": \"5\" }] }] }";
                    var result = JsonConvert.DeserializeObject(json, typeof(Result)) as Result;
                    result
                        .Telephones
                        .Where(x => x.TapiLine == "XX Line")
                        .ToList()
                        .ForEach(x => x.SpeakerList.RemoveAll(y => y.Ip == "192.168.10.204"));
    
                    json = JsonConvert.SerializeObject(result);
                    // write updated JSON back to the file
                }
            }
    
            class Result
            {
                public List<Telephone> Telephones { get; set; }
    
                public Result()
                {
                    Telephones = new List<Telephone>();
                }
            }
      
            class Telephone
            {
                public string TapiLine { get; set; }    
                public List<Speakers> SpeakerList { get; set; }
    
                public Telephone()
                {
                    SpeakerList = new List<Speakers>();
                }
            }
    
            class Speakers
            {
                public string Name { get; set; }   
                public string Ip { get; set; }
                public string Volume { get; set; }    
            }
        }
