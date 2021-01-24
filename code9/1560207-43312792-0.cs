    public MyClass()
    {
        //Default color
    }
    public MyClass(byte r_col, byte g_col, byte b_col)
    {
        color = Color.FromArgb(r_col, g_col, b_col);
    }
    public MyClass(byte a_col, byte r_col, byte g_col, byte b_col)
    {
        color = Color.FromArgb(a_col, r_col, g_col, b_col);
    }
