    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    using Microsoft.TeamFoundation.Client;
    using System;
    
    namespace TestCaseProject
    {
        class Program
        {
            static void Main(string[] args)
            {
                var tfs =
             TfsTeamProjectCollectionFactory.GetTeamProjectCollection(
                 new Uri("http://tfsserver:8080/tfs/CollectionName"));
                var service = tfs.GetService<WorkItemStore>();
    
                var wi = service.GetWorkItem(id);
    
    
                foreach (Field field in wi.Fields)
                {
                    Console.WriteLine("{0}: {1}", field.Name, field.Value);
                }
    
    
            }
        }
    }
