    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    using Microsoft.TeamFoundation.Client;
    using System;
    
    namespace GetWorkItemField
    {
        class Program
        {
            static void Main(string[] args)
            {
                var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("http://tfsserver:8080/tfs/teamprojectcollection"));
                var service = tfs.GetService<WorkItemStore>();
                string workItemQueryString = "Select Id, Title From WorkItems Where [System.TeamProject] = 'TeamProject'";
                var workItemQuery = new Query(service, workItemQueryString);
                WorkItemCollection queryResults = workItemQuery.RunQuery();
    
                foreach (WorkItem item in queryResults)
                {
                    var t = item.Fields["System.BoardColumn"];
                    Console.WriteLine("{0}: {1}", item.Title, t.Value);
                }
    
            }
        }
    }
