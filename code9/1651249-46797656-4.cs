    public event EventHandler ThingHappened;
    protected void OnThingHappened()
    {
        var member = ThingHappened;
        if (member != null)
        {
            member(this, EventArgs.Empty);
        }
    }
    public void SomeRandomMethod()
    {
        DoStuff();
        OnThingHappened();
        DoOtherStuff();
    }
