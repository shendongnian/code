    [DllExport("OutputAllAnalog", CallingConvention = CallingConvention.StdCall)]
    public static void OutputAllAnalogImplementation(int Data1, int Data2)
    {
        if (!_k8055D.Connected || Data1 < 0 || 255 < Data1 || 
                                 Data2 < 0 || 255 < Data2) return;
    
        _k8055D.AnalogOutputChannel[0] = (double)Data1 / 255 * 5;
        _k8055D.AnalogOutputChannel[1] = (double)Data2 / 255 * 5;
    }
    
    [DllExport("SetAllAnalog", CallingConvention = CallingConvention.StdCall)]
    public static void SetAllAnalog()
    {
        OutputAllAnalogImplementation(255, 255); //Fixed exception??
        test(); //No exception
    }
    public static void test()
    {
    }
