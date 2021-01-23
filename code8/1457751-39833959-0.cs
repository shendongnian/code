    public void myMethod(User u,Enum e)
    {
        if (e is EnumA)
        {
            EnumA ea = (EnumA)e;
            // Do something with ea
        }
        else if (e is EnumB)
        {
            EnumB eb = (EnumB)e;
            ...
        }
    }
