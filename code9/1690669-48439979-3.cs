    private static int myProperty = 0;
    public static int MyProperty
    {
        get { myProperty++; return myProperty; }
        set { myProperty = value; }
    }
