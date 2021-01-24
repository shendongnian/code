    TfsTeamProjectCollection TTPC = new TfsTeamProjectCollection(new Uri("http://xxx:8080/tfs/xxxCollection/"));
                WorkItemStore wis = TTPC.GetService<WorkItemStore>();
                string project = "projectname";
                string workitemid = "1";
                string wiql = $"SELECT [System.Id], [System.WorkItemType], [System.Title], [System.AssignedTo], [System.State], [System.Tags] FROM WorkItemLinks WHERE (Source.[System.TeamProject] = '{project}' and Source.[System.Id] = {workitemid}) and (Target.[System.TeamProject] = '{project}' and Target.[System.WorkItemType] = 'Task') ORDER BY [System.Id] mode(MustContain)";
                Query query = new Query(wis,wiql);
                WorkItemLinkInfo[] result = query.RunLinkQuery();
                List<WorkItem> tasks = new List<WorkItem> { };
                foreach (WorkItemLinkInfo wili in result)
                {
                    if (wili.SourceId == 0)
                    {
                        //Get the parent work item here.
                    }
                    else
                    {
                        //Get the details for the linked tasks and add to tasks list.
                        tasks.Add(wis.GetWorkItem(wili.TargetId));
                    }
                }
