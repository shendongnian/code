      using (var config = Assembly.GetExecutingAssembly().GetManifestResourceStream("MyFunc.logging.config"))
      {
          log4net.Config.XmlConfigurator.Configure(config);
      }
      var log = LogManager.GetLogger(context.FunctionName);
      log4net.GlobalContext.Properties["InvocationId"] = context.InvocationId;
