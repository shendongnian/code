    [System.AttributeUsage(System.AttributeTargets.Class)]  
    public class Teleporter : System.Attribute  
    { }
    [Teleporter()]
    public class Player { ... }
