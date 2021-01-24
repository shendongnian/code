	[XmlInclude(typeof(WindowsDevice))]
	[XmlInclude(typeof(AndroidDevice))]
	public abstract class Device
	{
	}
	
	public class WindowsDevice: Device
	{
	}
	
	public class AndroidDevice: Device
	{
	}
