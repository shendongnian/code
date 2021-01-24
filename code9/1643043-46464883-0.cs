    Unhandled Exception: System.MissingMethodException: Method not found: 'System.Collections.Generic.Dictionary`2<System.String,System.Object> Microsoft.Extensions.Configuration.IConfigurationBu
    ilder.get_Properties()'.
       at Microsoft.Extensions.Configuration.FileConfigurationExtensions.SetFileProvider(IConfigurationBuilder builder, IFileProvider fileProvider)
       at Microsoft.Extensions.Configuration.FileConfigurationExtensions.SetBasePath(IConfigurationBuilder builder, String basePath)
       at LicenseManager.Api.Startup..ctor(IHostingEnvironment env) in D:\Projekty\LicenseManager\src\LicenseManager.Api\Startup.cs:line 27
    --- End of stack trace from previous location where exception was thrown ---
       at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
       at Microsoft.Extensions.Internal.ActivatorUtilities.ConstructorMatcher.CreateInstance(IServiceProvider provider)
       at Microsoft.Extensions.Internal.ActivatorUtilities.CreateInstance(IServiceProvider provider, Type instanceType, Object[] parameters)
       at Microsoft.AspNetCore.Hosting.Internal.StartupLoader.LoadMethods(IServiceProvider hostingServiceProvider, Type startupType, String environmentName)
       at Microsoft.AspNetCore.Hosting.WebHostBuilderExtensions.<>c__DisplayClass1_0.<UseStartup>b__1(IServiceProvider sp)
       at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitFactoryService(FactoryService factoryService, ServiceProvider provider)
       at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(IServiceCallSite callSite, TArgument argument)
       at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScoped(ScopedCallSite scopedCallSite, ServiceProvider provider)
       at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitSingleton(SingletonCallSite singletonCallSite, ServiceProvider provider)
       at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(IServiceCallSite callSite, TArgument argument)
       at Microsoft.Extensions.DependencyInjection.ServiceProvider.<>c__DisplayClass16_0.<RealizeService>b__0(ServiceProvider provider)
       at Microsoft.Extensions.DependencyInjection.ServiceProvider.GetService(Type serviceType)
       at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService(IServiceProvider provider, Type serviceType)
       at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService[T](IServiceProvider provider)
       at Microsoft.AspNetCore.Hosting.Internal.WebHost.EnsureStartup()
       at Microsoft.AspNetCore.Hosting.Internal.WebHost.EnsureApplicationServices()
       at Microsoft.AspNetCore.Hosting.Internal.WebHost.BuildApplication()
       at Microsoft.AspNetCore.Hosting.WebHostBuilder.Build()
       at LicenseManager.Api.Program.Main(String[] args) in D:\Projekty\LicenseManager\src\LicenseManager.Api\Program.cs:line 15
