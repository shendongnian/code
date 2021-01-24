    public class Rootobject
    {
        public Playerstats playerstats { get; set; }
    }
    
    public class Playerstats
    {
        public string steamID { get; set; }
        public string gameName { get; set; }
        public Achievement[] achievements { get; set; }
        public bool success { get; set; }
    }
    
    public class Achievement
    {
        public string apiname { get; set; }
        public int achieved { get; set; }
        public int unlocktime { get; set; }
    }
