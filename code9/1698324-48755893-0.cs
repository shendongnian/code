    var infrastructureAssembly = typeof(AggregateRoot).GetTypeInfo().Assembly;
    var domainAssembly = typeof(CreateSite).GetTypeInfo().Assembly;
    var dataAssembly = typeof(IDataProvider).GetTypeInfo().Assembly;
    var reportingAssembly = typeof(GetAppAdminModel).GetTypeInfo().Assembly;
    var servicesAssembly = typeof(IMailService).GetTypeInfo().Assembly;
