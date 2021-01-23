    [Return()]
    void MyMethod(int x)
    {
        var skip = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttributes( typeof( ReturnAttribute ), false ).Any();
        if (skip) return;
        //Rest of the code goes here
    }
