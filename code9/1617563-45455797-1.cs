    private CandleCollection collection = null;
    public CandleCollection GetCandleCollection()
    {
        try
        {
            collection = SymbolList[cbxSymbol.Text];
        }
        return collection;
    }       
    private Class1 c1 = new Class1(collection);
    private void Print()
    {
            c1;
    }
    private void Print2()
    {
            c1;
    }
