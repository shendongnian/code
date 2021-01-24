    public void FuncOutParamString(ref StringBuilder sbValue)
    {
        sbValue.Append("wold!");
    }
    
    public void FuncOutParamString_(out StringBuilder sbValue)
    {
        sbValue = new StringBuilder();
        sbValue.Append("wold!");
    }
