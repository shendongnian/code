    using System;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string url = "http://xxx:8080/tfs/CollectionName/";
                string GlobalListName = "ListName";
                TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(new Uri(url));
                WorkItemStore wis = ttpc.GetService<WorkItemStore>();
                InternalAdmin.DestroyGlobalList(wis, GlobalListName, false);
            }
        }
    }
