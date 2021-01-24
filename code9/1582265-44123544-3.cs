    using System;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.Azure.WebJobs.ServiceBus;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    
    namespace Settlements.WebJob
    {
     public class ServiceJobActivator : IJobActivator
     {
      IServiceProvider _serviceProvider;
    
      public ServiceJobActivator(IServiceCollection serviceCollection) : base()
      {
        _serviceProvider = serviceCollection.BuildServiceProvider();
      }
    
      public T CreateInstance<T>()
      {
        return _serviceProvider.GetRequiredService<T>();
      }
     }   
    
       
    class Program
    {        
     static void Main()
     {  
       var config = new JobHostConfiguration();
        
       var dbConnectionString = Properties.Settings.Default.DefaultConnection;
                    
       var serviceCollection = new ServiceCollection();
       // wire up your services    
       serviceCollection.AddTransient<IThing, Thing>(); 
                        
       // important! wire up your actual jobs, too
       serviceCollection.AddTransient<ServiceBusJobListener>();
                    
       // added example to connect EF
       serviceCollection.AddDbContext<DbContext>(options =>
          options.UseSqlServer(dbConnectionString ));
                        
                        
       // add it to a JobHostConfiguration
       config.JobActivator = new ServiceJobActivator(serviceCollection);
                        
       var host = new JobHost(config);
                                    
       host.RunAndBlock();
       }
     }
   }
