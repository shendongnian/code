    public void FuncOutParamString(StringBuilder sbValue)
    {
        sbValue.Append("wold!");
    }
    
    public void FuncOutParamStringRef(ref StringBuilder sbValue)
    {
        //if(...)
            sbValue = new StringBuilder();
    }
    
    public void FuncOutParamStringOut(out StringBuilder sbValue)
    {
        sbValue = new StringBuilder();
    }
