    private static Form1 instance1;
    public string propertyForm1;
    public static Form1 Instance1
    {
        get
        {
            if (instance1 == null)
                instance1 = new Form1();
            return instance1;
        }
    }
