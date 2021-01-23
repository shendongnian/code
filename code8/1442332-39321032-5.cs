    // first, build the delegate in a normal way
    // and pick anything as the type parameters
    // we will later replace them
    var delegateWithNoType = new Action<object>(Blah);
    // delegate has captured the methodinfo,
    // but uses a stub type parameter - it's useless to call it
    // but it REMEMBERS the method!
    // .... pass the delegate around
    // later, elsewhere, determine the type you want to use
    Type myRealArgument;
    switch(..oversomething..)
    {
        default: throw new NotImplemented("Ooops");
        case ...: myRealArgument = typeof(UploadTypes.AutoIncident); break;
        ...
    }
    // look at the delegate definition
    var minfo = delegateWithNoType.Method;
    var target = delegateWithNoType.Target; // probably NULL since you cross layers
 
    var gdef = minfo.GetGenericDefinition();
    var newinfo = gdef.MakeGenericMethod( myRealArgument );
    // now you have a new MethodInfo object that is bound to Blah method
    // using the 'real argument' type as first generic parameter
    // By using the new methodinfo and original target, you could now build
    // an updated delegate object and use it instead the original "untyped" one
    // That would be a NEW delegate object. You can't modify the original one.
    // ...but since you want to call the method, why don't use the methodinfo
    UploadInformation upinfo = ... ;
    newinfo.Invoke(target, new object[] { upinfo });
    // -> will call Blah<UploadTypes.AutoInciden>(upinfo)
