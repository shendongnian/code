    using System;
    using System.Collections.Generic;
    using System.Management;
    using SiloStor.Tools;
    
    internal static void EnumerateClassPaths()
    {
    	try
    	{
    		// Enumerate all disk drives.
    		ManagementObjectSearcher oSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
    		foreach (ManagementObject wmiDisks in oSearcher.Get())
    		{
    			// Get the properties needed.
    			String propDiskRelpaths = wmiDisks["__RELPATH"].ToString();
    
    			// 
    			String wmiQuery1 = "ASSOCIATORS OF {" + propDiskRelpaths + "} WHERE ResultClass = Win32_PnpEntity";
    			foreach (ManagementObject wmiPnp in new ManagementObjectSearcher(wmiQuery1).Get())
    			{
    				// Get the properties needed.
    				String propPnpRelpaths = wmiPnp["__RELPATH"].ToString();
    
    				// 
    				String wmiQuery2 = "ASSOCIATORS OF {" + propPnpRelpaths + "}";
    				foreach (ManagementObject wmiDrivers in new ManagementObjectSearcher(wmiQuery2).Get())
    				{
    					String driverClass = wmiDrivers["__CLASS"].ToString();
    					String driverRelpath = wmiDrivers["__RELPATH"].ToString();
    					Console.WriteLine($"__CLASS   : {driverClass}");
    					Console.WriteLine($"__RELPATH : {driverRelpath}");
    					Console.WriteLine("");
    				}
    			}
    		}
    	}
    
    	catch (Exception ex)
    	{
    		// Log the error.
    		Errors.LogError(ex);
    	}
    }
