    [AttributeUsage(AttributeTargets.Class)]
    public class IdAttribute:Attribute
    {
        public Guid Id { get; }
        public IdAttribute(string id)
        {
            Id = new Guid(id);
        }
    }
