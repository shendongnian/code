    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class XmlBaseTypeAttribute : System.Attribute
	{
	}	
	[XmlInclude(typeof(WindowsDevice))]
	[XmlInclude(typeof(AndroidDevice))]
	[XmlBaseType]
	public abstract class Device
	{
	}
