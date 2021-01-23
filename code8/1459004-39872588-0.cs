    TSGetRootObject ts = new TSGetRootObject(); 
    ts.aliases.Add(new MeetingAliases {
           alias = "alias",
           conference = "conference",
           description = "description",
           id = 1
        }); 
    ts.name = id;
    ts.service_type = srvtype;
    ts = TransfomationSrv.PostData(ts);
    
    public class TSGetRootObject
    {
    
        [DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<MeetingAliases> aliases { get; set; }
        [DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? allow_guests { get; set; }
        public TSGetRootObject(){
            aliases = new List<MeetingAliases>();
        }
    }
    
    public class MeetingAliases
    { 
        [DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string alias { get; set; }
        [DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string conference { get; set; }
        [DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string description { get; set; }
        [DataMember]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? id { get; set; }
    }
