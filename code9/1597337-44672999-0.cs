    using System;
    using Xamarin.Forms;
    [assembly: Dependency(typeof(PortableInterfaceRenderer))]
    namespace YourProjectName.iOS
    {
    
    	public class PortableInterfaceRenderer : PortableInterface
    	{
    		public object GetLogicFromAndroidProject()
    		{
    			throw new NotImplementedException(); // here write your logic 
    		}
    	}
    }
