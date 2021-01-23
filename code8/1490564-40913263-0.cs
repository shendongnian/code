    public static string ReturnApplicationVersion()
    {
    	System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
    	FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
    	string versionMajor = fvi.ProductMajorPart.ToString();
    	string versionMinor = fvi.ProductMinorPart.ToString();
    	string versionBuild = fvi.ProductBuildPart.ToString();
    	string versionPrivate = fvi.ProductPrivatePart.ToString();
    
    	string fVersion = fvi.FileVersion;
    	return versionMajor + "." + versionMinor + "." + versionBuild + "." + versionPrivate;
    }
