    public class TSGetRootObject
    {
        public TSGetRootObject
        {
            aliases = new List<MeetingAliases>();
        }
    
        //Or in c# 6.0 or higher:
        public List<MeetingAliases> aliases { get; set; } = new List<MeetingAliases>();
    }
