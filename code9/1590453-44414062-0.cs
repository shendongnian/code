    TfsTeamProjectCollection tfsTeamProjects = new TfsTeamProjectCollection(new Uri(tfsServerUrl));
    WorkItemStore tfsWorkItemStore = tfsTeamProjects.GetService<WorkItemStore>();
    WorkItem tfsWorkItem = tfsWorkItemStore.GetWorkItem(tfsWorkItemId);
    FileInfo fi = new FileInfo(@"D:\\New Text Document.txt");
    Attachment tfsAttachment = new Attachment(fi.FullName);
    tfsWorkItem.Attachments.Add(tfsAttachment);
    tfsWorkItem.Save();
    foreach (Attachment tfsAttachment in tfsWorkItem.Attachments)
                    {
                        // Do things here
                    }
