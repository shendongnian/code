    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false)]
    public sealed class AssemblyChannelAttribute : Attribute
    {
        public ChannelType Type { get; private set; }
        public AssemblyChannelAttribute(ChannelType type)
        {
            this.Type = type;
        }
    }
    public enum ChannelType
    {
        Dev,
        Beta,
        PreProd,
        Prod
    }
