    public sealed class AttributeCollection : AttributeCollectionBase
    {
        //... We don't need anything here to start. Maybe add something specific.
    }
    public class SomeCharacter
    {
        //...
        public AttributeCollection Attributes { get; }
    }
    var someCharacter = new SomeCharacter();
