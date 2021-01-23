    public void SomeMethod()
    {
        var foo = new Ninject.Parameters.ConstructorArgument("iamInterface", new Implement2());
        IProcessContext pc = kernel.Get<IProcessContext>(foo);            
    }
