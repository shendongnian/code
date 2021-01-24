     loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
                loggerFactory.AddAzureWebAppDiagnostics(
                    new AzureAppServicesDiagnosticsSettings
                    {
                        OutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss zzz} [{Level}] {RequestId}-{SourceContext}: {Message}{NewLine}{Exception}",
    
                    }
                );
