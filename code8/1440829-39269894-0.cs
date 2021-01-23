    public abstract class AbstractOptions { }
    public class Options1 : AbstractOptions { public int Whatever { get; set; } }
    public class Options2 : AbstractOptions { public string Some { get; set; } }
    public class Options3 : AbstractOptions {
      [JsonProperty("when")] public DateTime When { get; set; }
      [JsonProperty("inner")] public InnerComplexObject Inner { get; set; }
    }
    public class Request {
      [JsonProperty("session-id")] public string SessionId { get; set; }
      [JsonProperty("options")] public AbstractOptions Options { get; set; }
    }
    public class InnerComplexObject { }
