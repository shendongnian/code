    //pd is a PrintDocument. used like:
    PrintController printController = new StandardPrintController();
    pd.PrintController = printController;
	NullPrinter np = new NullPrinter();                
	if (!np.NullPortExists())
	{
	   np.CreateNullPort();
	}
	
	if (!np.NullPrinterExists())
	{
	    np.CreateNullPrinter();
	}
	pd.PrinterSettings.PrinterName = "NUL_PRINTER";
	/*********************************************/	
	using System;
	using System.Management; // This must also be added as a reference
	using System.Drawing.Printing;
	using System.Runtime.InteropServices;
	namespace YourFavoriteNamespace
	{
	    //
	    // This helper class has methods to determine whether a 'Nul Printer' exists,
	    // and to create a null port and null printer if it does not.
	    //
	    public class NullPrinter
	    {
		// Printer port management via Windows GUI (Windows 7, probably same in other versions):
		// 
		//      Go to printers & devices
		//      Select any printer
		//      Click on Print server properties
		//      Select Ports tab
		//      Add or remove (local) port
		//      To remove a local port, if "in use", stop and restart the print spooler service.
		//      It seems that the most recently used port will be "in use" until the system restarts,
		//      or until another port is used.
		//      A port may also be added when adding a printer.
		//      Valid names for a Null port appear to be NUL, NULL, NUL: - all case insensitive. 
		public bool NullPortExists()
		{
		    for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
		    {
			   string printerName = PrinterSettings.InstalledPrinters[i];
			   string query = string.Format("SELECT * from Win32_Printer WHERE Name LIKE '%{0}'", printerName);
			   ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
			   ManagementObjectCollection coll = searcher.Get();
			   foreach (ManagementObject printer in coll)
			   {
			       string pName = printer["PortName"].ToString();
			       if (pName.Equals("NULL", StringComparison.InvariantCultureIgnoreCase) ||
				    pName.Equals("NUL", StringComparison.InvariantCultureIgnoreCase) ||
				    pName.Equals("NUL:", StringComparison.InvariantCultureIgnoreCase))
			       {
				    return true;
			       }
			   }
		    }
		    return false;
		}
		// The application that uses this requires a printer specifically named "NUL_PRINTER"
		public bool NullPrinterExists()
		{
		    for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
		    {
			    if (PrinterSettings.InstalledPrinters[i] == "NUL_PRINTER")
			    {
			        return true;
			    }
		    }
		    return false;
		}
		public bool CreateNullPort()
		{
		    return Winspool.AddLocalPort("NUL") == 0 ? true : false;
		}
		public void CreateNullPrinter()
		{
		    Winspool.AddPrinter("NUL_PRINTER");
		}
	}
	/*********************************************************/
	    //
	    // This Winspool class was mostly borrowed and adapted 
	    // from several different people's blog posts, 
	    // the links to which I have lost. 
	    // Thank you, whoever you are.
	    //
	    public static class Winspool
	    {
    		[StructLayout(LayoutKind.Sequential)]
	    	private class PRINTER_DEFAULTS
		    {
		        public string pDatatype;
		        public IntPtr pDevMode;
    		    public int DesiredAccess;
	    	}
		    [DllImport("winspool.drv", CharSet = CharSet.Auto)]
    		static extern IntPtr AddPrinter(string pName, uint Level, [In] ref PRINTER_INFO_2 pPrinter);
	    	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		    struct PRINTER_INFO_2
		    {
		        public string pServerName,
        		  pPrinterName,
    				  pShareName,
		    		  pPortName,
    				  pDriverName,
    				  pComment,
    				  pLocation;
	    	    public IntPtr pDevMode;
    		    public string pSepFile,
    				  pPrintProcessor,
	    			  pDatatype,
    				  pParameters;
    		    public IntPtr pSecurityDescriptor;
    		    public uint Attributes,
    				  Priority,
    				  DefaultPriority,
    				  StartTime,
    				  UntilTime,
    				  Status,
    				  cJobs,
    				  AveragePPM;
    		}
    		[DllImport("winspool.drv", EntryPoint = "XcvDataW", SetLastError = true)]
    		private static extern bool XcvData(
    		    IntPtr hXcv,
    		    [MarshalAs(UnmanagedType.LPWStr)] string pszDataName,
    		    IntPtr pInputData,
    		    uint cbInputData,
    		    IntPtr pOutputData,
    		    uint cbOutputData,
    		    out uint pcbOutputNeeded,
    		    out uint pwdStatus);
 
	    	[DllImport("winspool.drv", EntryPoint = "OpenPrinterA",  SetLastError = true)]
    		private static extern int OpenPrinter(
    		    string pPrinterName,
    		    ref IntPtr phPrinter,
    		    PRINTER_DEFAULTS pDefault);
    
    		[DllImport("winspool.drv", EntryPoint = "ClosePrinter")]
    		private static extern int ClosePrinter(IntPtr hPrinter);
  
	    	public static int AddLocalPort(string portName)
    		{
    		    PRINTER_DEFAULTS def = new PRINTER_DEFAULTS();
    		    def.pDatatype = null;
    		    def.pDevMode = IntPtr.Zero;
    		    def.DesiredAccess = 1; //Server Access Administer
 
	    	    IntPtr hPrinter = IntPtr.Zero;
		        int n = OpenPrinter(",XcvMonitor Local Port", ref hPrinter, def);
    		    if (n == 0)
    			return Marshal.GetLastWin32Error();
    
	    	    if (!portName.EndsWith("\0"))
    			portName += "\0"; // Must be a null terminated string
    		    // Must get the size in bytes. .NET strings are formed by 2-byte characters
    		    uint size = (uint)(portName.Length * 2);
    		    // Alloc memory in HGlobal to set the portName
    		    IntPtr portPtr = Marshal.AllocHGlobal((int)size);
    		    Marshal.Copy(portName.ToCharArray(), 0, portPtr, portName.Length);
    		    uint NotUsedByUs;
    		    uint xcvResult; 
    		    XcvData(hPrinter, "AddPort", portPtr, size, IntPtr.Zero, 0,  out NotUsedByUs, out xcvResult);
    		    ClosePrinter(hPrinter);
    		    Marshal.FreeHGlobal(portPtr);
    		    return (int)xcvResult;
    		}
			
    		public static void AddPrinter(string PrinterName)
    		{
    		  IntPtr mystrptr = new IntPtr(0);    
    		  IntPtr mysend2;
    		  PRINTER_INFO_2 pi = new PRINTER_INFO_2();
    		  pi.pServerName =  "";
    		  pi.pPrinterName = PrinterName;
    		  pi.pShareName = "NUL";
    		  pi.pPortName = "NUL";
    		  pi.pDriverName = "Generic / Text Only";
    		  pi.pComment = "No Comment";
    		  pi.pLocation = "Local";
    		  pi.pDevMode = mystrptr;
    		  pi.pSepFile = "";
    		  pi.pPrintProcessor = "WinPrint";
	    	  pi.pDatatype = "RAW";
    		  pi.pParameters = "";
    		  pi.pSecurityDescriptor = mystrptr;
    		  mysend2 = AddPrinter(null,2, ref pi);                    
    		}
        }
	}
