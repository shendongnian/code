    static void Main(string[] args)
    {            
        var r = new Record("Support-28", "TEST USER", 0, "", "", "TEST CODE", "", 0, 0, "", "");
        string jsonStr = JsonConvert.SerializeObject(r);
        //var json_record = JsonConvert.DeserializeObject<Record>(System.Text.Encoding.ASCII.GetString(byte_slice));
        var json_record = JsonConvert.DeserializeObject<Record>(jsonStr);
        Console.ReadLine();
    }
    public class Record
    {
        public string Station;
        public string UserName;
        public int EvtActive;
        public string EvtTime;
        public string EvtTimeString;
        public string LocCode;
        public string LastLoop;
        public int CompLvl;
        public int RecordID;
        public string ConnectTime;
        public string Notes;
        public string Color;
        public Record(string station, string userName, int evtActive, string evtTime, string evtTimeString, string locCode, string lastLoop, int compLvl, int recordIDi, string connectTime, string notes)
        {
            this.Station = station;
            this.UserName = userName;
            this.EvtActive = evtActive;
            this.EvtTime = evtTime;
            this.EvtTimeString = evtTimeString;
            this.LocCode = locCode;
            this.LastLoop = lastLoop;
            this.CompLvl = compLvl;
            this.RecordID = recordIDi;
            this.ConnectTime = connectTime;
            this.Notes = notes;
            this.Color = "red";
            SwordsServer.Records.Add(this);
            Console.WriteLine("Creating Record");
            Console.WriteLine(this.Station);
            Console.WriteLine(this.UserName);
            Console.WriteLine(this.LocCode);
        }
    }
    public static class SwordsServer
    {
        static SwordsServer()
        {
            Records = new List<Record>();
        }
        public static List<Record> Records { get; set;}
    }
