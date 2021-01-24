    var dependencyModule = Microsoft.ApplicationInsights.Extensibility.Implementation.TelemetryModules.Instance.Modules
        .OfType<Microsoft.ApplicationInsights.DependencyCollector.DependencyTrackingTelemetryModule>()
        .FirstOrDefault();
    if (dependencyModule != null)
    {
        var domains = dependencyModule.ExcludeComponentCorrelationHttpHeadersOnDomains;
        domains.Add("management.azure.com");
    }
