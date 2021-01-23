    public interface IMetadataExtension
    {
        string Foo { get; }
    }
    public class MetadataExtension : IMetadataExtension
    {
        public string Foo { get; set; }
    }
    [MetadataAttribute]
    public class MetadataExtensionAttribute : Attribute, IMetadataExtension
    {
        public MetadataExtensionAttribute(string foo)
        {
            Foo = foo;
        }
        public string Foo { get; }
    }
    [Export]
    [MetadataExtension("bar")]
    public class SomeExport
    {
    }
