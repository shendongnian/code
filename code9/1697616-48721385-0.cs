    public void Foo<T>(T instance) where T : ClassA
    {
       GenericFoo(instance);
    }
    public void Foo<T>(T instance) where T : ClassB
    {
        GenericFoo(instance);
    }
    private void GenericFoo(object instance)
    {
      // Do stuff
    }
