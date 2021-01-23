    using cloudscribe.Core.Models;
    using cloudscribe.Core.Models.Setup;
    using cloudscribe.Core.Web;
    using cloudscribe.Core.Web.Components;
    using cloudscribe.Core.Web.Components.Editor;
    using cloudscribe.Core.Web.Components.Messaging;
    using cloudscribe.Core.Web.Navigation;
    using cloudscribe.Web.Common.Razor;
    using cloudscribe.Web.Navigation;
    using cloudscribe.Web.Navigation.Caching;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection.Extensions;
    using Microsoft.Extensions.FileProviders;
    using Microsoft.Extensions.Options;
    using System.Reflection;
    using Microsoft.AspNetCore.Authorization;
    namespace Microsoft.Extensions.DependencyInjection
    {
        public static class StartupExtensions
        {
            public static IServiceCollection AddCloudscribeCore(this IServiceCollection services, IConfigurationRoot configuration)
            {
                services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                services.Configure<MultiTenantOptions>(configuration.GetSection("MultiTenantOptions"));
                services.Configure<SiteConfigOptions>(configuration.GetSection("SiteConfigOptions"));
                services.Configure<UIOptions>(configuration.GetSection("UIOptions"));
                services.Configure<CkeditorOptions>(configuration.GetSection("CkeditorOptions"));
                services.Configure<CachingSiteResolverOptions>(configuration.GetSection("CachingSiteResolverOptions"));
                services.AddMultitenancy<SiteContext, CachingSiteResolver>();
                services.AddScoped<CacheHelper, CacheHelper>();
                services.AddScoped<SiteManager, SiteManager>();
                services.AddScoped<GeoDataManager, GeoDataManager>();
                services.AddScoped<SystemInfoManager, SystemInfoManager>();
                services.AddScoped<IpAddressTracker, IpAddressTracker>();
                services.AddScoped<SiteDataProtector>();
                services.AddCloudscribeCommmon();
                services.AddScoped<ITimeZoneIdResolver, RequestTimeZoneIdResolver>();
                services.AddCloudscribePagination();
                services.AddScoped<IVersionProviderFactory, VersionProviderFactory>();
                services.AddScoped<IVersionProvider, CloudscribeCoreVersionProvider>();
                services.AddTransient<ISiteMessageEmailSender, SiteEmailMessageSender>();
                services.AddTransient<ISmsSender, SiteSmsSender>();
                services.AddSingleton<IThemeListBuilder, SiteThemeListBuilder>();
                services.TryAddScoped<ViewRenderer, ViewRenderer>();
                services.AddSingleton<IOptions<NavigationOptions>, SiteNavigationOptionsResolver>();
                services.AddScoped<ITreeCacheKeyResolver, SiteNavigationCacheKeyResolver>();
                services.AddScoped<INodeUrlPrefixProvider, FolderTenantNodeUrlPrefixProvider>();
                services.AddCloudscribeNavigation(configuration);
                services.AddCloudscribeIdentity();
                return services;
            }
       
        }
    }
