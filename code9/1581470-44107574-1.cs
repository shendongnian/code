    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
            Uri collectionUri = (args.Length < 1) ?
                new Uri("http://servername:8080/tfs/MyCollection") : new Uri(args[0]);
            // Connect to the server and the store. 
            TfsTeamProjectCollection teamProjectCollection =
               new TfsTeamProjectCollection(collectionUri);
             WorkItemStore workItemStore = teamProjectCollection.GetService<WorkItemStore>();
            string queryString = "Select [State], [Title],[Description] From WorkItems Where [Work Item Type] = 'Code Review Request' or [Work Item Type] = 'Code Review Response'";
            // Create and run the query.
            Query query = new Query(workItemStore, queryString);
            WorkItemCollection witCollection = query.RunQuery();
            foreach (WorkItem workItem in witCollection)
            {
                workItem.Open();
                Console.WriteLine(workItem.Fields["Title"].Value.ToString());
            }
