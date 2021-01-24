c#
public void ConfigureServices(IServiceCollection services)
{
  // Add cors
  services.AddCors();
  // Add framework services.
  services.AddMvc()
  .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
  // load application parts from a non-referenced 'extension' assembly:
  var path = @"c:\extensions\CustomController.dll";
  var assembly = Assembly.LoadFile(path);
  services.AddApplicationPart(assembly);
  // ...
}
