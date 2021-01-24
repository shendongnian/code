    private object UnmarshalDelegate(GenericEventSink generic)
    {
      var pars = generic.OriginalType.GenericTypeArguments.Select(Expression.Parameter).ToArray();
        
      // create the call
      var method = generic.GetType().GetMethod("OnMessageReceived" + pars.Length);
      var call = Expression.Call(Expression.Constant(generic), method, pars.Select(p => Expression.Convert(p, typeof(object))));
      return Expression.Lambda(generic.OriginalType, call, pars).Compile();
    }
