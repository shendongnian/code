    public class InnerThing
    {
    	public int Chats { get; set; }
    	public int Missed_Chats { get; set; }
    }
    var result = JsonConvert.DeserializeObject<Dictionary<string, InnerThing>>(json);
