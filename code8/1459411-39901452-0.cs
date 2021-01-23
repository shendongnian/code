    //A couple of custom attributes
    public class MyAttributeOne : Attribute { }
    public class MyAttributeTwo : Attribute { }
    //A metadata class where we can use the custom attributes
    public sealed class MyEntityMetadata
    {
        //This property has the same name as the class it is referring to
    	[MyAttributeOne]
    	public int SomeProperty { get; set; }
    }
    //And an entity class where we use System.ComponentModel.DataAnnotations.MetadataType
    //to tell our function where the metadata is stored
    [MetadataType(typeof(MyEntityMetadata))]
    public class MyEntity
    {
    	public int SomeProperty { get; set; }
    }
