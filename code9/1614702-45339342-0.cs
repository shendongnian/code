    public bool IsDebugBuild 
    { 
        get
        {
            #if DEBUG
            return true;
            #else
            return false;
            #endif
        }
    }
