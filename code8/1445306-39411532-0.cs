    static Action<Stream, object> GetWriteDelegateForType(Type type)
    {
        // get the actual generic method
        var handlerObj = GetHandlerForType(type);
        var methodInfo = handlerObj
                    .GetType()
                    .GetMethod("Write", new[] { typeof(MemoryStream), type });
        // but use (Stream, object) parameters instead
        var streamArg = Expression.Parameter(typeof(Stream), "s");
        var objectArg = Expression.Parameter(typeof(object), "v");
        // this will cast object to T
        var tCast = Expression.Convert(objectArg, type);
        var handlerObjConstant = Expression.Constant(handlerObj);
        var body = Expression.Call(handlerObjConstant, methodInfo, streamArg, tCast);
        var lambda = Expression.Lambda<Action<Stream, object>>(body, streamArg, objectArg);
        // and compile to an actual Action<Stream, object>
        return lambda.Compile();
    }
