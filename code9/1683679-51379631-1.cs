        using System.Reflection;
        using System.Web.Http;
        using Abp.Application.Services;
        using Abp.Configuration.Startup;
        using Abp.Modules;
        using Abp.WebApi;
        
        namespace YourApp.Api
        {
            [DependsOn(typeof(AbpWebApiModule), 
            typeof(YourAppCommonModule), 
            typeof(YourAppApplicationModule))]
            public class YourAppWebApiModule : AbpModule
            {
                public override void Initialize()
                {
                    IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        
                    Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                        .ForAll<IApplicationService>(typeof(YourAppCommonModule).Assembly, "app")
                        .Build();
        
                    Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                        .ForAll<IApplicationService>(typeof(YourAppApplicationModule).Assembly, "app")
                        .Build();
        
                    Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));
                }
            }
        }
