    // This is the "default" behavior registration for when
    // no parameters are provided. Note it's named, though, so
    // the actual default registration for IAThing will be the
    // lambda.
    builder.RegisterType<AThing>().Named<IAThing>("default-thing");
    // This is what will run when you Resolve<IAThing>()
    builder.Register((ctx, p) => {
      var aorb = p
        .OfType<NamedParameter>()
        .Where(n => n.Name == "aParam")
        .FirstOrDefault();
      if (aorb != null)
      {
        // You passed the parameter so use it.
        return new AThing((BParam)aorb.Value);
      }
      else
      {
        // Use the default reflection-based registration, above.
        return ctx.ResolveNamed<IAThing>("default-thing", p);
      }
    }).As<IAThing>();
