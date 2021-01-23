    // Attach resolved parameters to override Autofac's
    // lookup just on the ISender parameters.
    builder.RegisterType<ShippingProcessor>()
           .WithParameter(
             new ResolvedParameter(
               (pi, ctx) => pi.ParameterType == typeof(ISender),
               (pi, ctx) => ctx.Resolve<PostalServiceSender>()));
    builder.RegisterType<CustomerNotifier>();
           .WithParameter(
             new ResolvedParameter(
               (pi, ctx) => pi.ParameterType == typeof(ISender),
               (pi, ctx) => ctx.Resolve<EmailNotifier>()));
    var container = builder.Build();
