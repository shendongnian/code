    private int num1;
    public int Num1
    {
        get
        {
            return num1;
        }
        set
        {
            num1 = value;
            Label.Content = num1;
        }
    }
    // Elsewhere
    Num1 = 15; // Assign to the property rather than the field directly
