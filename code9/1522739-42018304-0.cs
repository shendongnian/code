                    document.Add(
                    new JsonPatchOperation()
                    {
                        Path = "/relations/-",
                        Operation = Microsoft.VisualStudio.Services.WebApi.Patch.Operation.Add,
                        Value = new
                        {
                            rel = "System.LinkTypes.Hierarchy-Reverse",
                            url = collectionUri + "/_apis/wit/workItems/" + porWorkItemID.ToString(),
                            attributes = new
                            {
                                comment = "Making a new link for the dependency"
                            }
                        }
                        });
