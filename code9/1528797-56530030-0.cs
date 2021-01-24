csharp
[HttpOptions("/find")]
public IActionResult FindOptions()
{
    Response.Headers.Add("Access-Control-Allow-Origin", new[] { (string)Request.Headers["Origin"] });
    Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Origin, X-Requested-With, Content-Type, Accept" });
    Response.Headers.Add("Access-Control-Allow-Methods", new[] { "POST, OPTIONS" }); // new[] { "GET, POST, PUT, DELETE, OPTIONS" }
    Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });
    return NoContent();
}
## 
csharp
[HttpPost("/find")]
public async Task<IActionResult> FindOptions([FromForm]Find_POSTModel model)
{
    AllowCrossOrigin();
    
    // your code...
}
private void AllowCrossOrigin()
{
    Uri origin = null;
    Uri.TryCreate(Request.Headers["Origin"].FirstOrDefault(), UriKind.Absolute, out origin);
    if (origin != null && IsOriginAllowed(origin))
        Response.Headers.Add("Access-Control-Allow-Origin", $"{origin.Scheme}://{origin.Host}");
}
And of course, you can implement `IsOriginAllowed` as you wish
csharp
private bool IsOriginAllowed(Uri origin)
{
    const string myDomain = "mydomain.com";
    const string[] allowedDomains = new []{ "example.com", "sub.example.com" };
    return 
           allowedDomains.Contains(origin.Host) 
           || origin.Host.EndsWith($".{myDomain}");
}
You can find more details on [how to enable CORS for POST requests on a single endpoint](https://dotnetstories.com/blog/How-to-enable-CORS-for-POST-requests-on-a-single-endpoint-in-ASPNET-Core-en-7186478980)
