	using System.Management;
	//...
	//create a management scope object
	ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\CIMV2\\TerminalServices");
	
	//create object query
	ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_TerminalServiceSetting");
	
	//create object searcher
	ManagementObjectSearcher searcher =
	                        new ManagementObjectSearcher(scope, query);
	
	//get a collection of WMI objects
	ManagementObjectCollection queryCollection = searcher.Get();
	
	//enumerate the collection.
	foreach (ManagementObject m in queryCollection) 
	{
	  // access properties of the WMI object
	  Console.WriteLine("Terminal server enabled : {0}", m["AllowTSConnections"]);
    }
