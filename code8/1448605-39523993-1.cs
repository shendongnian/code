    var appInfo = new Infrastructure.ApplicationInfo();
    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(nWatchApp.Configuration.NWatchDatabase);
    appInfo.NWatchDatabaseCatalog = builder.InitialCatalog;
    appInfo.NWatchDatabaseServer = builder.DataSource;
    var context = nWatchApp.GetDbContext();
    builder = new SqlConnectionStringBuilder(context.DatabaseConnectionString);
    appInfo.EntityDatabaseCatalog = builder.InitialCatalog;
    appInfo.EntityDatabaseServer = builder.DataSource;
    // Store 'appInfo' in RAM
    Infrastructure.Utility.AppInfo = appInfo;
