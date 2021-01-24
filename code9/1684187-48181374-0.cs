    var url = new Uri("https://XXX.visualstudio.com"); 
                var connection = new VssConnection(url, new VssClientCredentials());
                var workitemClient = connection.GetClient<WorkItemTrackingHttpClient>();
                string projectName = "[project name]";
                int parentWITId = 771;//parent work item id
                var patchDocument = new Microsoft.VisualStudio.Services.WebApi.Patch.Json.JsonPatchDocument();
                patchDocument.Add(new Microsoft.VisualStudio.Services.WebApi.Patch.Json.JsonPatchOperation() {
                    Operation=Operation.Add,
                    Path= "/fields/System.Title",
                    Value="parentandchildWIT"
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
