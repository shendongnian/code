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
    
                for (int i = result.Telephones.Count - 1; i >= 0; i--)
                {
                    if (result.Telephones[i].TapiLine == "XX Line")
                    {
                        for (int j = result.Telephones[i].SpeakerList.Count - 1; j >= 0; j--)
                        {
                            if (result.Telephones[i].SpeakerList[j].Ip == "192.168.10.204")
                            {
                                result.Telephones[i].SpeakerList.RemoveAt(j);
                            }
                        }
                    }
                }
    
                json = JsonConvert.SerializeObject(result);
                // write updated json back to the file
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
