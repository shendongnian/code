    public override Object DefaultValue { get { return GetDefaultValue(false); } }
    public override Object RawDefaultValue { get { return GetDefaultValue(true); } }
    private Object GetDefaultValue(bool raw)
    {
        // ... Precheck
        object defaultValue = GetDefaultValueInternal(raw);
        // ... Postprocessing
        return defaultValue;
    }
    [System.Security.SecuritySafeCritical]
    private Object GetDefaultValueInternal(bool raw)
    {
        // ... Too long to include, but it contains "if (raw)"
        // ... a couple of times to do different things.
        return defaultValue;
    }
