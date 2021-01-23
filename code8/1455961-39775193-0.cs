    public enum ServerType
    {
        Web,
        Database,
        SomethingElse
    }
    public class ServerA : ServerObject
    {
    }
    public class ServerB : ServerObject
    {
    }
    public abstract class ServerObject
    {
        public ServerType ServerType { get; set; }
    }
