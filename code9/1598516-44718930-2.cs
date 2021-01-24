    var u = new Uri("https://[account].visualstudio.com");
                VssCredentials c = new VssCredentials(new Microsoft.VisualStudio.Services.Common.VssBasicCredential(string.Empty, "[personal access token]"));
               var connection = new VssConnection(u, c);
    
    var workitemClient = connection.GetClient<WorkItemTrackingHttpClient>();
    var workitemtype = "Product Backlog Item";
                string teamProjectName = "Scrum2015";
                var document = new Microsoft.VisualStudio.Services.WebApi.Patch.Json.JsonPatchDocument();
                document.Add(
        new Microsoft.VisualStudio.Services.WebApi.Patch.Json.JsonPatchOperation()
        {
            Path = "/fields/Microsoft.VSTS.Common.Discipline",
            Operation = Microsoft.VisualStudio.Services.WebApi.Patch.Operation.Add,
            Value = "development"
        });
                document.Add(
                    new Microsoft.VisualStudio.Services.WebApi.Patch.Json.JsonPatchOperation()
                    {
                        Path = "/fields/System.Title",
                        Operation = Microsoft.VisualStudio.Services.WebApi.Patch.Operation.Add,
                        Value = string.Format("{0} {1}", "RESTAPI", 6)
                    });
                document.Add(new Microsoft.VisualStudio.Services.WebApi.Patch.Json.JsonPatchOperation()
                {
                    Path = "/fields/System.AreaPath",
                    Operation = Microsoft.VisualStudio.Services.WebApi.Patch.Operation.Add,
                    Value =string.Format("{0}\\{1}",teamProjectName, "SharedArea")
                });
                document.Add(
                    new Microsoft.VisualStudio.Services.WebApi.Patch.Json.JsonPatchOperation()
                    {
                        Path = "/fields/System.AssignedTo",
                        Operation = Microsoft.VisualStudio.Services.WebApi.Patch.Operation.Add,
                        Value = "[user account]"
                    });
                document.Add(
                    new Microsoft.VisualStudio.Services.WebApi.Patch.Json.JsonPatchOperation()
                    {
                        Path = "/fields/System.Description",
                        Operation = Microsoft.VisualStudio.Services.WebApi.Patch.Operation.Add,
                        Value = "destest"
                    });
    var workitem= workitemClient.CreateWorkItemAsync(document, teamProjectName, workitemtype).Result;
