    public void GunAction(Base o)
    {
        if(o is Derived1 )
            o.Gun();
        if(o is Derived2 )
            o.Gun();
    }
