    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ClientIpAuthorizeAttribute : Attribute
    {
        public string AllowedIpAddress { get; set; }
    }
