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
                WorkItemStore _wistore = new WorkItemStore("http://myserver/myCollection");
                int _id = 210;
                string _wiql = String.Format("SELECT [System.Id] FROM WorkItemLinks WHERE ([Source].[System.WorkItemType] = 'Feature') And ([System.Links.LinkType] = 'System.LinkTypes.Hierarchy-Forward') And ([Target].[System.Id] = {0}  AND  [Target].[System.WorkItemType] = 'Task') ORDER BY [System.Id] mode(Recursive,ReturnMatchingChildren)", _id);
                Query _query = new Query(_wistore, _wiql);
                WorkItemLinkInfo[] _links = _query.RunLinkQuery();
                if (_links.Count() > 1) //first item contains feature
                    Console.WriteLine("Parent ID: " + _links[0].TargetId);
                else
                    Console.WriteLine("There is no parent for ID: " + _id);
            }
        }
    }
