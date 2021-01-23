    using System.Runtime.CompilerServices;
    
    [assembly: InternalsVisibleTo("FriendAssemblyTest")]
    [assembly: InternalsVisibleTo("FriendAssemblyTestLibrary")]
    
    namespace GlobalData
    {
    	internal static class GlobalData
    	{
    		internal static string Member { get; set; }
    		internal static decimal TestDecimal { get; set; }
    	}
    }
