    services.AddTransient<IAuthorizable, AuthorizeService>();
    services.AddTransient<IEditable, ConfigureService>();
    services.AddTransient<IRequested, RequestService>();
    services.AddTransient<RequestService, RequestService>(); //<-- 
    services.AddTransient<INotified, NotificationService>();
    services.AddHangfire(x => x.UseSqlServerStorage("ConnectionString"));
