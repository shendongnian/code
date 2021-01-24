    private int[] generatedNums
    {
        get { return (int[])HttpContext.Current.Session["generatedNums"]; }
        set { HttpContext.Current.Session["generatedNums"] = value; }
    }
