    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
            Uri collectionUri = (args.Length < 1) ?
                new Uri("http://servername:8080/tfs/MyCollection") : new Uri(args[0]);
            // Connect to the server and the store. 
            TfsTeamProjectCollection teamProjectCollection =
               new TfsTeamProjectCollection(collectionUri);
            WorkItemStore workItemStore = teamProjectCollection.GetService<WorkItemStore>();
            WorkItem wi = workItemStore.GetWorkItem(109);  //get workitem by workitem id
            string wiType = wi.Fields["Work Item Type"].Value.ToString();
            if (wiType == "Code Review Request" || wiType == "Code Review Response")
            {
                //This is a code review workitem 
            }
            else
            {
                //This is not a code review workitem
            }
