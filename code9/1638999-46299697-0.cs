    [XmlInclude(typeof(IpClass))]
    [XmlInclude(typeof(FileClass))]
    [XmlInclude(typeof(StringValue))]
    public abstract class AbstractValue : INullable
    {   
        public virtual bool IsNull => Value == null;
    }
    public sealed class IpValue : AbstractValue
    {   
        public IpClass Value { get; set; }
    }
    public sealed class FileValue : AbstractValue
    {   
        public FileClass Value { get; set; }
    }
    public sealed class StringValue : AbstractValue
    {   
        public string Value { get; set; }
    }
