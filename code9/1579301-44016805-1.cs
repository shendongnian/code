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
                //get all build definitions in your team projects
                List<BuildDefinitionReference> builddefs = buildServer.GetDefinitionsAsync(project:"team project name").Result;   
                foreach (BuildDefinitionReference builddef in builddefs)
                {
                    Console.WriteLine(builddef.Name);
                    ...
                }
                //get all builds information in your team projects
                var builds = buildServer.GetBuildsAsync(project: "team project name").Result;
                foreach (var build in builds)
                {
                    Console.WriteLine(build.Definition.Name + "--" + build.BuildNumber + "--" +build.Result);
                }
            }
