    public class Player
    {
        [JsonProperty("chatOff")]
        public List<Hotkey> ChatOff { get; set; }
        [JsonProperty("chatOn")]
        public List<Hotkey> ChatOn { get; set; }
    }
    public class Hotkey
    {
        [JsonProperty("actionsetting")]
        public ActionSetting ActionSetting;
        [JsonProperty("keysequence")]
        public string Shortcut { get; set; }
    }
    public class ActionSetting
    {
        [JsonProperty("useObject")]
        public int UseObject { get; set; }
        [JsonProperty("chatText")]
        public string ChatText { get; set; }
        [JsonProperty("useType")]
        public string UseType { get; set; }
        [JsonProperty("sendAutomatically")]
        public bool SendAutomatically { get; set; }
    }
