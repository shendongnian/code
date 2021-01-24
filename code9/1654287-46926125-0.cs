    public void Traverse(Func<Amounts, decimal> getter)
    {
        var a = new Amounts();
        decimal result = getter(a);
    }
    //...
    
    Traverse(t => t.Amount1);
    Traverse(t => t.Amount2);
