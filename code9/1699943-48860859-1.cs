    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
    using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
    using Microsoft.VisualStudio.Services.Common;
    using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
    using Microsoft.VisualStudio.Services.WebApi.Patch;
    using Microsoft.VisualStudio.Services.WebApi;
    using System.Net.Http.Headers;
    using System.Net.Http;
    using Newtonsoft.Json;
    
    public class ExecuteQuery
    {
        readonly string _uri;
        readonly string _personalAccessToken;
        readonly string _project;
    
        /// <summary>
        /// Constructor. Manually set values to match your account.
        /// </summary>
        public ExecuteQuery()
        {
            _uri = "https://accountname.visualstudio.com";
            _personalAccessToken = "personal access token";
            _project = "project name";
        }
    
        /// <summary>
        /// Execute a WIQL query to return a list of bugs using the .NET client library
        /// </summary>
        /// <returns>List of Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem</returns>
        public List<WorkItem> RunGetBugsQueryUsingClientLib()
        {
            Uri uri = new Uri(_uri);
            string personalAccessToken = _personalAccessToken;
            string project = _project;
    
            VssBasicCredential credentials = new VssBasicCredential("", _personalAccessToken);
    
            //create a wiql object and build our query
            Wiql wiql = new Wiql()
            {
                Query = "Select [State], [Title] " +
                        "From WorkItems " +
                        "Where [Work Item Type] = 'Bug' " +
                        "And [System.TeamProject] = '" + project + "' " +
                        "And [System.State] <> 'Closed' " +
                        "Order By [State] Asc, [Changed Date] Desc"
            };
    
            //create instance of work item tracking http client
            using (WorkItemTrackingHttpClient workItemTrackingHttpClient = new WorkItemTrackingHttpClient(uri, credentials))
            {
                //execute the query to get the list of work items in the results
                WorkItemQueryResult workItemQueryResult = workItemTrackingHttpClient.QueryByWiqlAsync(wiql).Result;
    
                //some error handling                
                if (workItemQueryResult.WorkItems.Count() != 0)
                {
                    //need to get the list of our work item ids and put them into an array
                    List<int> list = new List<int>();
                    foreach (var item in workItemQueryResult.WorkItems)
                    {
                        list.Add(item.Id);
                    }
                    int[] arr = list.ToArray();
    
                    //build a list of the fields we want to see
                    string[] fields = new string[3];
                    fields[0] = "System.Id";
                    fields[1] = "System.Title";
                    fields[2] = "System.State";
    
                    //get work items for the ids found in query
                    var workItems = workItemTrackingHttpClient.GetWorkItemsAsync(arr, fields, workItemQueryResult.AsOf).Result;
    
                    Console.WriteLine("Query Results: {0} items found", workItems.Count);
    
                    //loop though work items and write to console
                    foreach (var workItem in workItems)
                    {
                        Console.WriteLine("{0}          {1}                     {2}", workItem.Id, workItem.Fields["System.Title"], workItem.Fields["System.State"]);
                    }
    
                    return workItems;
                }
    
                return null;
            }
        }
    }
