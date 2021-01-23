    [DataContract]
    public class App
    {
        [DataMember(Name = "appid")]
	    public int Appid { get; set; }
	    [DataMember(Name = "name")]
	    public string Name { get; set; }
    }
