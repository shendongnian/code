    var url= new Uri("https://XXX.visualstudio.com");
                    VssCredentials c = new VssCredentials(new Microsoft.VisualStudio.Services.Common.VssBasicCredential(string.Empty, "[personal access token]"));
    var connection = new VssConnection(url, c);
                var workitemClient = connection.GetClient<WorkItemTrackingHttpClient>();
                string projectName = "scrum2015";
                int parentWITId = 771;
                var patchDocument = new Microsoft.VisualStudio.Services.WebApi.Patch.Json.JsonPatchDocument();
                patchDocument.Add(new Microsoft.VisualStudio.Services.WebApi.Patch.Json.JsonPatchOperation() {
                    Operation=Operation.Add,
                    Path= "/fields/System.Title",
                    Value="childWIT"
                });
                patchDocument.Add(new Microsoft.VisualStudio.Services.WebApi.Patch.Json.JsonPatchOperation()
                {
                    Operation = Operation.Add,
                    Path = "/relations/-",
                    Value = new
                    {
                        rel = "System.LinkTypes.Hierarchy-Reverse",
                        url = connection.Uri.AbsoluteUri+ projectName+ "/_apis/wit/workItems/"+parentWITId,
                        attributes = new
                        {
                            comment = "link parent WIT"
                        }
                    }
                });
                var createResult = workitemClient.CreateWorkItemAsync(patchDocument, projectName, "task").Result;
