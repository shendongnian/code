	public class BaseClass
	{
	}
	public class DerivedClass : BaseClass
	{
	}
	public class RootObject
	{
		[XmlElement(ElementName = "BaseClassProperty", Type = typeof(BaseClass))]
		[XmlElement(ElementName = "DerivedClassProperty", Type = typeof(DerivedClass))]
		public BaseClass Property { get; set; }
	}
