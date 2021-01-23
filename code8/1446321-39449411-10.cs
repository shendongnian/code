    public void GunAction(Derived2 o)
    {
        o.Gun();
    }
    public void GunAction(Derived1 o)
    {
        o.Gun();
    }
    public void GunAction(Base o)
    {
        Trace.Log("I'm base class, i can't do anything");
    }
