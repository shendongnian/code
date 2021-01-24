    const byte minVSVersion=11; // Visual Studio 2012
    const byte maxVSVersion=14; // Visual Studio 2015
    
    static List<string> getVSUsers()
    {
    	var vsUsrs=new List<string>();
    	for(byte version=minVSVersion; version<=maxVSVersion; version++)
    		vsUsrs.Add((string)Registry.GetValue(
    			@"HKEY_USERS\.DEFAULT\Software\Microsoft\VisualStudio\"+version+@".0_Config\Registration",
    			"UserName", null));
    				
    	return vsUsrs.Where(usr => usr!=null).ToList();
    }
