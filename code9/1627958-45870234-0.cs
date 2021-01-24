    public static CustomType CatchException(Action a)
    {
        CustomType ct = new CustomType();
        try
        {
            a();
        }
        catch
        {
            ct.Passed = false;
        }
        return ct;
    }
