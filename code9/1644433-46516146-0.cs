    using Microsoft.AspNetCore.Http.Features;
    using System.Net;
    ....
    var connection = HttpContext.Features.Get<IHttpConnectionFeature>();
    IPAddress clientIP = connection.RemoteIpAddress;
