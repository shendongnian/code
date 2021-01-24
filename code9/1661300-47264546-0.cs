       TfsTeamProjectCollection teamProjectCollection =
                   new TfsTeamProjectCollection(collectionUri);
    WorkItemStore workItemStore = teamProjectCollection.GetService<WorkItemStore>();
    
    string queryString = "select [System.Id], [System.WorkItemType], [System.Title], [System.AssignedTo], [System.State], [System.Tags] from WorkItems where [System.TeamProject] = 'YourTeamProjectName' and [System.WorkItemType] <> '' and [System.ChangedDate] >= @today - 30 order by [System.Id]";
    
    // Create and run the query.
    Query query = new Query(workItemStore, queryString);
    WorkItemCollection witCollection = query.RunQuery();
    
    foreach (WorkItem workItem in witCollection)
    {
    
          foreach (WorkItemLink wiLink in workItem.WorkItemLinks)
    
          {
                 //find if the link type is parent/chind
                if (wiLink.LinkTypeEnd.Name.Equals("Parent")|| wiLink.LinkTypeEnd.Name.Equals("Child"))
                 {
                           .......
                 }
           }
     }
