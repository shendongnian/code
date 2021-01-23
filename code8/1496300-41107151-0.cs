    // If you're using "mixed types"
    public void CalcBreakpoint(int tolerance, params object[] args)
    {
       //...
    }
    // The use of dynamic here is controversial but it can accomplish something similar to the above code sample
    public void void CalcBreakpoint(int tolerance, params dynamic[] args)
    {
        //....
    }
    // If all of the arguments are of the same type but you don't know "in advance"
    // what that type will be, you can use generics here
    public void CalcBreakpoint<T>(int tolerance, params T[] args)
    {
        //my code
    }
