    Parallel.ForEach(items, item =>
    {
         // Note I'm calling container.BeginLifetimeScope() here
         using (var parallelScope = container.BeginLifetimeScope())
         {
             var aDataService = parallelScope.Resolve<IaDataService>();
             aDataService.SomeProcessing();
         }
     }
