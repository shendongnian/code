csharp
public void ConfigureServices(IServiceCollection services)
{
    var assembly = typeof(**AnyTypeFromRequiredAssembly**).Assembly;
    services.AddControllers()
        .PartManager.ApplicationParts.Add(new AssemblyPart(assembly));
}
