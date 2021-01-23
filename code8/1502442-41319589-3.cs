    private bool hasRunMethod1 = false;
    
    public void method1()
    {
        Contract.Ensures( this.hasRunMethod1 );
        //Method 1
        hasRunMethod1 = true;
    }
    
    public void method2()
    {
        Contract.Requires( this.hasRunMethod1 );
        //Should call this only after calling method1
    }
