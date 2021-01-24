                    String path= @"path";
                    var store = tfsCollection.GetService<WorkItemStore>();
                    Microsoft.TeamFoundation.WorkItemTracking.Client.WorkItem wi = store.GetWorkItem(testCaseId);
                    wi.Attachments.Add(new Attachment(path));
                    wi.Save();                    
