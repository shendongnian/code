    public class ComponentValue : IEquatable<ComponentValue>
    {
            public String Id { get; set; }
            public String Name { get; set; }
            public String DisplayName { get; set; }
            public IList<ComponentValue> ChildComponents { get; set; }
            public bool Equals(ComponentValue other)
            {
                return Id == other.Id && Name == other.Name;
            }
    }
