    public MyClassB(MyClassB param)
    {
        Width = param.Width;
        // If you want to keep the same reference classA
        paramClassA = param.paramClassA;
        // if you want the classA to not be the same reference you could always do.
        paramClassA = new MyClassA() { Width =  param.Width };
    }
