    [DllImport("test.dll")]
    public static extern int get_size();
    
    [DllImport("test.dll")]
    public static extern void get_string(int resultSize, StringBuilder result);
