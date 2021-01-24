    public event EventHandler ThingHappened;
    protected void OnThingHappened()
    {
        var handler = ThingHappened;
        if (handler != null)
        {
            handler(this, EventArgs.Empty);
        }
    }
    public void SomeRandomMethod()
    {
        DoStuff();
        OnThingHappened();
        DoOtherStuff();
    }
