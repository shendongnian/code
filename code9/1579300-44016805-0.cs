    using Microsoft.VisualStudio.Services.WebApi;
    using Microsoft.VisualStudio.Services.Common;
    using Microsoft.TeamFoundation.Build.WebApi;
    using Microsoft.TeamFoundation.Core.WebApi;
    using Microsoft.VisualStudio.Services.Operations;
            public static void GetBuild()
            {
                var u = new Uri("http://servername:8080/tfs/MyCollection/");
                VssCredentials c = new VssCredentials(new Microsoft.VisualStudio.Services.Common.WindowsCredential(new NetworkCredential("v-tinmo", "123456.w", "fareast")));
                VssConnection connection = new VssConnection(u, c);
    
                BuildHttpClient buildServer = connection.GetClient<BuildHttpClient>();
                List<BuildDefinitionReference> builddefs = buildServer.GetDefinitionsAsync(project:"team project name").Result;   
                foreach (BuildDefinition builddef in builddefs)
                {
                    Console.WriteLine(builddef.Name);
                    ...
                }
            }
