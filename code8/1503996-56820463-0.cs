c#
services.AddApiVersioning(options =>
    options.Conventions.Add( new VersionByNamespaceConvention() );
Your service now only need be defined as:
c#
[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
public class MyController : ControllerBase
{
    // GET: ~/api/v1/my/status
    [HttpGet]
    public IActionResult Status()
    {
        return Ok(new { status = "API is running" });
    }
}
