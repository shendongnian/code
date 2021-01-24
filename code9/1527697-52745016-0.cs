    using System.Security.Principal;
    
    namespace MyNamespace
    {
    	public static class MainClass
    	{
    		public static void Main(string[] args)
    		{
    			RequireAdministrator();
    		}
    
    		private static void RequireAdministrator()
    		{
    			using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
    			{
    				WindowsPrincipal principal = new WindowsPrincipal(identity);
    				if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
    				{
    					throw new InvalidOperationException("Application must be run as administrator");
    				}
    			}
    		}
    	}
    }
