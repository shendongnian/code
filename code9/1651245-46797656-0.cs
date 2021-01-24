    public Action DoParentThing { get; set; }
    public void SomeOtherRandomMethod()
    {
        DoStuff();
        if (DoParentThing != null)
        {
            DoParentThing();
        }
        DoOtherStuff();
    }
