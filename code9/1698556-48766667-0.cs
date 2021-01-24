    public IMyObj CreateType1(string param1, int param2)
    {
        return new MyObj1(param1, param2);
    }    
    public IMyObj CreateType2(bool param1, string param2, int param3) 
    {
        return new MyObj2(param1, param2, param3);
    }
