	static void Main()
    {    
        var sb = new StringBuilder();           
        Console.WriteLine("Calling AppendDebugInfo1");
        AppendDebugInfo1(sb);
        Console.WriteLine("Calling AppendDebugInfo2");
        AppendDebugInfo2(sb);
        Console.WriteLine(sb);
    }
    [Conditional("DEBUG")]
    public static void AppendDebugInfo1(StringBuilder sb)
    {
        sb.AppendLine("DEBUG is defined");
    }
    [Conditional("DEBUG"), Conditional("SUPERDEBUG"))]  
    public static void AppendDebugInfo2(StringBuilder sb)
    {
        sb.AppendLine("DEBUG or SUPERDEBUG is defined! whoaaaaa!");
    }
