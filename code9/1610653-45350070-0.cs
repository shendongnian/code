     if (Configuration.GetValue<string>("UseResilientHttp") == bool.TrueString)
      {
          services.AddSingleton<IResilientHttpClientFactory, ResilientHttpClientFactory>();
          services.AddSingleton<IHttpClient, ResilientHttpClient>(sp => sp.GetService<IResilientHttpClientFactory>().CreateResilientHttpClient());
      }
      else
      {
          services.AddSingleton<IHttpClient, StandardHttpClient>();
      }
