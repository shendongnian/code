    var u = new Uri("[collection url]");
    VssCredentials c = new VssCredentials(new Microsoft.VisualStudio.Services.Common.WindowsCredential(new NetworkCredential("v-stache", "Hua543@Hua543", "fareast")));
                var connection = new VssConnection(u, c);
                var workitemClient = connection.GetClient<WorkItemTrackingHttpClient>();
     var result = workitemClient.QueryByWiqlAsync(new Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.Wiql() { Query = "select[System.Id] from WorkItems where [System.TeamProject] = 'ScrumStarain2' and [System.WorkItemType] = 'Product Backlog Item' and [System.State] <> ''" }, "ScrumStarain2").Result;
