      public static void Main()
      {
          JobHostConfiguration config = new JobHostConfiguration();
          config.UseTimers();
          JobHost host = new JobHost(config);
          host.RunAndBlock();
      }
