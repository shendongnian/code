    // note that i've changed Object to MyObject 
    public MyObject(MyObject parObject)
    {
        Version v;
        if(Version.TryParse(parObject.VersionString, out v))
        {
            this.Version = v;
        }
        else
            throw new ArgumentException("invalid version: " + parObject.VersionString);
    }
    
    public Version Version { get; set; }
