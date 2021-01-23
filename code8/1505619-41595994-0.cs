    Ivi.Visa.Interop.ResourceManager rm = new Ivi.Visa.Interop.ResourceManager();
    Ivi.Visa.Interop.FormattedIO488 ioobj = new Ivi.Visa.Interop.FormattedIO488();
    
    try
    {
    
    	object[] idnItems;
    
    	ioobj.IO = (Ivi.Visa.Interop.IMessage)rm.Open("GPIB2::10::INSTR",
    	Ivi.Visa.Interop.AccessMode.NO_LOCK, 0, "");
    
    	ioobj.WriteString("*IDN ?", true);
    
    	idnItems = (object[])ioobj.ReadList(Ivi.Visa.Interop.IEEEASCIIType.ASCIIType_Any, ",");
    
    	foreach(object idnItem in idnItems)
    	{
    		System.Console.Out.WriteLine("IDN Item of type " + idnItem.GetType().ToString());
    		System.Console.Out.WriteLine("\tValue of item is " + idnItem.ToString());
    	}
    
    }
    catch(Exception e)
    {
    	System.Console.Out.WriteLine("An error occurred: " + e.Message);
    }
    finally
    {
    
    	try { ioobj.IO.Close(); }
    	catch { }
    
    	try
    	{
    		System.Runtime.InteropServices.Marshal.ReleaseComObject(ioobj);
    	}
    	catch { }
    
    	try
    	{
    		System.Runtime.InteropServices.Marshal.ReleaseComObject(rm);
    	}
    	catch { }
    }
