    builder.RegisterType<EmployerFunctions>().As<IEmployerFunctions>();
    builder.Register<Func<HttpRequestMessage, IMetaDataSaver>>(delegate(IComponentContext context)
		{
            if (request.IsReciprocal())
            {
                return new ReciprocalMetaDataSaver();
            }
            else
           {
               IComponentContext cc = context.Resolve<IComponentContext>();
               var functions = cc.Resolve<IEmployerFunctions>();
               return new EmployerMetaDataSaver(functions); //<--error is here
           }
        });
