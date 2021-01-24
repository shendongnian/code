    [DllExport("Fu", CallingConvention = CallingConvention.StdCall)]
    public static int Fu()
    {
	    // Stuff
    }
    [DllExport("Bar", CallingConvention = CallingConvention.StdCall)]
    public static int Bar()
    {
	    Fu();
    }
