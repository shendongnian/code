    using System;
    using Newtonsoft.Json;
    namespace Demo
    {
        public class Rootobject
        {
            public Systemsingal[] SystemsInGal { get; set; }
        }
        public class Systemsingal
        {
            public string Name { get; set; }
            public int xPos { get; set; }
            public int yPos { get; set; }
            public Stationsinsy[] StationsInSys { get; set; }
        }
        public class Stationsinsy
        {
            public string Name { get; set; }
            public string SystemName { get; set; }
            public int DistanceFromStar { get; set; }
            public int PricePerFuel { get; set; }
        }
        class Program
        {
            static void Main()
            {
                string data =
                    @"{
      ""SystemsInGal"": [
        {
          ""Name"": ""HIP 16607"",
          ""xPos"": 0,
          ""yPos"": 0,
          ""StationsInSys"": [
            {
              ""Name"": ""Thome Gateway"",
              ""SystemName"": ""HIP 16607"",
              ""DistanceFromStar"": 2573,
              ""PricePerFuel"": 10
            }
          ]
        },
        {
          ""Name"": ""Frenis"",
          ""xPos"": 10,
          ""yPos"": 10,
          ""StationsInSys"": [
            {
              ""Name"": ""Parsons City"",
              ""SystemName"": ""Frenis"",
              ""DistanceFromStar"": 32,
              ""PricePerFuel"": 20
            }
          ]
        }
      ]
    }";
                var result = JsonConvert.DeserializeObject<Rootobject>(data);
                Console.WriteLine(result.SystemsInGal.Length);
            }
        }
    }
