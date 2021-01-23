     public class oVesselMovement //notice no ancestor class or interfaces
        {
            public int wpID { get; set; }
            public string charts { get; set; }
            public string latNS { get; set; }
            public string longEW { get; set; }
            public string course { get; set; }
            public double toNextWPNM { get; set; }
            public double toGoNM { get; set; }
            public string eda { get; set; }
            public string eta { get; set; }
        }
    
        public class RootVM
        {
            public List<oVesselMovement> jsnObj { get; set; }
        }
    
        public class MakeItSo
        {
            public const string json = "{\"jsnObj\":[{\"vmID\":\"1\",\"charts\":\"2111\",\"latNS\":\"10°29.10 N\",\"longEW\":\"123°25.83 E\",\"course\":\"420°\",\"toNextWPNM\":0,\"toGoNM\":\"27\",\"eda\":\"12-15-2016\",\"eta\":\"11:01\"},{\"vmID\":\"2\",\"charts\":\"2211\",\"latNS\":\"11°29.10 N\",\"longEW\":\"124°25.83 E\",\"course\":\"420°\",\"toNextWPNM\":0,\"toGoNM\":\"27\",\"eda\":\"12-15-2016\",\"eta\":\"11:01\"}]}";
    
            public void SaveVmd()
            {
                RootVM rootObj = JToken.Parse(json).ToObject<RootVM>();
                Console.WriteLine($"Parsed {rootObj.jsnObj.Count} vessel movement objects");
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var makeitso = new MakeItSo();
                makeitso.SaveVmd();
            }
        }
