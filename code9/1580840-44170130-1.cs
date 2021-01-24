    [BeforeSet("StringValue")]
    public void BeforeSetStringValue(PropertyInterceptorArgs<MyEntity, string> args)
    {
        //When the string is set, 'sync' it to the IntValue property
        (this.EntityAspect as IStructuralObject).SetValueRaw(PropertyMetadata.IntValue, int.Parse(args.Value));
    }
    [BeforeSet("IntValue")]
    public void BeforeSetIntValue(PropertyInterceptorArgs<MyEntity, int> args)
    {
        //When the int is set, 'sync' it to the StringValue property
        //Introduce a delay so the deadlock will obviously happen.  In our real app, we don't have
        //  a Thread.Sleep() but we do have non-trivial logic that can cause just enough delay for the deadlock
        //  to happen sometimes
        Thread.Sleep(2000);
        (this.EntityAspect as IStructuralObject).SetValueRaw(PropertyMetadata.StringValue, args.Value.ToString());
    }
