      option 1:
        c.Register<ConsoleWriter>(
          Made.Of(() => new ConsoleWriter(Arg.Index<string>(0)), 
          _ => c.Resolve<ApplicationConfiguration>().SomeConfigurationValue));
      option 2: if you change the ConsoleWriter constructor to public
        c.Register<ConsoleWriter>(made: Parameters.Of
         .Name("message", _ => c.Resolve<ApplicationConfiguration>().SomeConfigurationValue));
      option 3: the simplest, may be the best one to use.
        c.RegisterDelegate<ConsoleWriter>(
            r => new ConsoleWriter(r.Resolve<ApplicationConfiguration>().SomeConfigurationValue));
