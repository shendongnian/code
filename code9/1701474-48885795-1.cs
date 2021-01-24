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
                int _id = 175;
                string _wiql = String.Format("SELECT [System.Id] FROM WorkItemLinks WHERE ([Source].[System.Id] = {0}) And ([System.Links.LinkType] = 'System.LinkTypes.Hierarchy-Reverse') And ([Target].[System.WorkItemType] = 'Feature') ORDER BY [System.Id] mode(MustContain)", _id);
                Query _query = new Query(_wistore, _wiql);
                WorkItemLinkInfo[] _links = _query.RunLinkQuery();
                if (_links.Count() == 2) //only 1 child and its parent
                    Console.WriteLine("Parent ID: " + _links[1].TargetId);
                else
                    Console.WriteLine("There is no parent for ID: " + _id);
            }
        }
    }
