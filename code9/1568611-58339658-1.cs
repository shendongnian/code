using NHibernate;
using System;
using Microsoft.Extensions.DependencyInjection;
namespace MyAmazingApplication
{
    public class DependencyInjectionInterceptor : EmptyInterceptor
    {
        private readonly IServiceProvider _serviceProvider;
        public DependencyInjectionInterceptor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public T GetService<T>() => _serviceProvider.GetService<T>();
        public T GetRequiredService<T>() => _serviceProvider.GetRequiredService<T>();
    }
}
Startup.cs:
public void ConfigureServices(IServiceCollection services)
{
    ...
    var cfg = new Configuration();
    ... // your config setup
    cfg.SetListeners(NHibernate.Event.ListenerType.PreInsert, new[] { new AuditEventListener() });
    cfg.SetListeners(NHibernate.Event.ListenerType.PreUpdate, new[] { new AuditEventListener() });
    services.AddSingleton(cfg);
    services.AddSingleton(s => s.GetRequiredService<Configuration>().BuildSessionFactory());
    services.AddScoped(s => s.GetRequiredService<ISessionFactory>().WithOptions().Interceptor(new     DependencyInjectionInterceptor(s)).OpenSession());
    ... // you other services setup
}
AuditEventListener.cs:
public class AuditEventListener : IPreUpdateEventListener, IPreInsertEventListener
{
    public bool OnPreUpdate(PreUpdateEvent e)
        {
            var user = ((DependencyInjectionInterceptor)e.Session.Interceptor).GetService<ICurrentUser>();
            if (e.Entity is IEntity)
                UpdateAuditTrail(user, e.State, e.Persister.PropertyNames, (IEntity)e.Entity, false);
            return false;
        }
}
So you use interceptor to get your scoped or any other service:
var myService = ((DependencyInjectionInterceptor)e.Session.Interceptor).GetService<IService>();
I hope it might be helpful for everyone.
