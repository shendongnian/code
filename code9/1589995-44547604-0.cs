    using Microsoft.TeamFoundation.Build.WebApi;
    using Microsoft.VisualStudio.Services.Common;
    using Microsoft.VisualStudio.Services.WebApi;
    using System;
    using System.Net;
    
    var u = new Uri("http://ourtfsserver:8080/tfs/DefaultCollection/");
    var c = new VssCredentials(new Microsoft.VisualStudio.Services.Common.WindowsCredential(new NetworkCredential("username", "password", "domain")));
    var connection = new VssConnection(u, c);
    var buildServer = connection.GetClient<BuildHttpClient>();
    var changesets = buildServer.GetBuildChangesAsync("projectname", 3807).Result;
