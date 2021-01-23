    // produce wmi query object
    ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Printer);
    // produce search object
    ManagementObjectSearcher search = new ManagementObjectSearcher(quer);
    // retrieve result collection
    ManagementObjectCollection restul = search.Get();
    // iterate through all printers 
    foreach(ManagementObject obj in result)
    {
        // now create your temp printer class
        Dictionary<string, object> printerObj = new Dictionary<string, object>();
        if(obj.GetPropertyValue("Local").ToString().Equals("true"))
        {
            printerObj.Add("isLocal", true);
            printerObj.Add("name", obj.GetPropertyValue("name").ToString());
        }
        else 
        {
            printerObj.Add("isLocal", false);
            printerObj.Add("serverName", obj.GetPropertyValue("ServerName").ToString());
            printerObj.Add("shareName", obj.GetPropertyValue("ShareName").ToString());
        }
        // create real printer object
        PrintServer srv = ((bool)printerObj["isLocal")) ? new LocalPrintServer() : new PrintServer((string)printerObj["serverName"]);
        PrintQueue queue = srv.GetPrintQueue(((bool)printerObj["isLocal")) ? (string)printerObj["name"] : (string)printerObj["shareName"];
        foreach(var job in queue.GetPrintJobInfoCollection())
        {
            // check job info and if it matches, return printer name;
        }
    }
