    // Fixed at 2 parameters
    public IGrid Create2DGrid(bool rule1, bool rule2)
    {
        if (twoParamsOk)
        {
            Create2DGrid(new [] { rule1, rule2 });
        }
    }
    // Fixed at 3 parameters
    public IGrid Create2DGrid(bool rule1, bool rule2, bool rule3)
    {
        if (threeParamsOk)
        {
            Create2DGrid(new [] { rule1, rule2, rule3 });
        }
    }
    private IGrid Create2Grid(bool[] rules)
    {
        if (rules.Length != 2)
            throw new ArgumentException("need 2 rules);
    } 
