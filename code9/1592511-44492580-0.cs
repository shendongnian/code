     var u = new Uri("https://starain.visualstudio.com");
     VssCredentials c = new VssCredentials(new Microsoft.VisualStudio.Services.Common.VssBasicCredential(string.Empty, "[pat]"));
                var connection = new VssConnection(u, c);
                var workItemTracking = connection.GetClient<WorkItemTrackingHttpClient>();
     Microsoft.TeamFoundation.Core.WebApi.ProjectHttpClient projClient = connection.GetClientAsync<Microsoft.TeamFoundation.Core.WebApi.ProjectHttpClient>().Result;
               var projects= projClient.GetProjects().Result;
                foreach(var p in projects.Where(pro=>pro.Name=="Scrum2015"))
                {
                    var iteration = workItemTracking.GetClassificationNodeAsync(project: p.Name, structureGroup: Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.TreeStructureGroup.Iterations, depth: 5).Result;
                    GetIterations(iteration);
                }
    
    
     static void GetIterations(Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItemClassificationNode currentIteration)
            {
                Console.WriteLine(currentIteration.Name);
                if(currentIteration.Children!=null)
                {
                    foreach (var ci in currentIteration.Children)
                    {
                        GetIterations(ci);
                    }
                } 
            }
