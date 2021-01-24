    [DllExport("Fu", CallingConvention = CallingConvention.StdCall)]
    public static int Fu()
    {
	    LocalFu();	
    }
    private static int LocalFu()
    {
	    // Stuff
    }
    [DllExport("Bar", CallingConvention = CallingConvention.StdCall)]
    public static int Bar()
    {
        // Stuff
	    LocalFu();
        // Other stuff
    }
