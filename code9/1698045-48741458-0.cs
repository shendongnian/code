    public CheckBox[];
    protected void Page_Load(object sender, EventArgs e)
    {
        /* ... other code ... */
        Chk = new CheckBox[dt.Columns.Count];
     
        for (int i = 0; i <= dt.Columns.Count - 1; i ++)
        {
            Chk [i] = new CheckBox();
        
            /* ... other code ... */
        }
    }
