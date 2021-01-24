    public class Host
    {
       public string name { get; set; }
    }
    public class RootObject
    {
        public string display_name { get; set; }
        public string plugin_output { get; set; }
    	[JsonProperty("host")]
    	public Host h { get; set; }
    	public string Host { get { return this.h.name;} set {this.h.name = value;}}
    }
