    private static int myProperty = 0;
    public static int MyProperty
    {
        get { MyProperty++; return myProperty; }
        set { myProperty = value; }
    }
