    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace QueryLinkedWIQL
    {
        class Program
        {
            static void Main(string[] args)
            {
                WorkItemStore _wistore = new WorkItemStore("http://server/collection");
                string _teamProject = "VSTSScrum";
                string _teamPhoneixRootIteration = "VSTSScrum\\Phoneix";
                string _teamSSRootIteration = "VSTSScrum\\SS";
                    string _wiql = string.Format("SELECT [System.Id] FROM WorkItemLinks WHERE ([Source].[System.TeamProject] = '{0}'"+ 
                    "AND ( [Source].[System.WorkItemType] = 'Bug'  OR  [Source].[System.WorkItemType] = 'Product Backlog Item'  OR  [Source].[System.WorkItemType] = 'Feature' ) " + 
                    "AND ( [Source].[System.IterationPath] UNDER '{1}'  OR  [Source].[System.IterationPath] UNDER '{2}' )) " + 
                    "And ([System.Links.LinkType] = 'System.LinkTypes.Hierarchy-Forward') And " + 
                    "([Target].[System.WorkItemType] = 'Task'  OR  [Target].[System.WorkItemType] = 'Product Backlog Item') ORDER BY [System.Id] mode(Recursive)",
                    _teamProject, _teamPhoneixRootIteration, _teamSSRootIteration);
                Query _query = new Query(_wistore, _wiql);
                WorkItemLinkInfo[] _links = _query.RunLinkQuery();
                foreach(WorkItemLinkInfo _link in _links)
                {
                    //process link info item ....
                }
            }
        }
    }
