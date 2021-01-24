    public MyClass(byte? r_col = null, byte? g_col = null, byte? b_col = null, byte a_col = 255)
    {
        if (r_col == null | g_col == null | b_col == null)
        {
            // use default color
        }
        else
        {
            System.Windows.Media.Color.FromArgb(a_col,
                                                r_col.GetValueOrDefault(),
                                                g_col.GetValueOrDefault(),
                                                b_col.GetValueOrDefault());
        }
    }
