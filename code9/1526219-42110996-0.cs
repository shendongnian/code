    [HttpPost]
    [ActionName("probe")]
    public Dictionary<string, List<DataSample>> getMultiProbe(string server, [FromBody] Dictionary<string,Object> request)
    {       
        Debug.WriteLine("ENTER [GetMultiProbe] "+ request["from"] + " -   mode: " + request["mode"]);
        string[] tagnames = (string [])request["tagnames"];
        return null;        
    }
    
    [HttpPost]
    [ActionName("currentmultiprobe")]
    public Dictionary<string, Object[]> getCurrentMultiProbe(string server, [FromBody] String[] tagnames)
    {       
        Debug.WriteLine("ENTER [getCurrentMultiProbe] server: " + server + " - tagnames: " + tagnames);
        return null;
    }
