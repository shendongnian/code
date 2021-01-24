    using Microsoft.TeamFoundation.Client;
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
            static List<string> ListTeams(TfsTeamProjectCollection pTpc, Project pProject)
            {
                TfsTeamService _teamService = pTpc.GetService<TfsTeamService>();
                var _teams = _teamService.QueryTeams(pProject.Uri.ToString());
                return (from t in _teams select t.Name).ToList();
            }
            static string ConstructTeamsString(string pProjectName, List<string> pTeamNames)
            {
                string _val = "";
                for(int  i = 0; i< pTeamNames.Count; i++)
                    if (pTeamNames[i] == "SS" || pTeamNames[i] == "Phoneix") // I have many teams without iteration root name. So I use this if to remove unneeded teams. You can remove this line
                        _val += ((_val != "") ? " OR " : "") + string.Format("[Source].[System.IterationPath] UNDER '{0}\\{1}'", pProjectName, pTeamNames[i]);
                return _val;
            }
            static void Main(string[] args)
            {
                string _teamProject = "VSTSScrum";
                TfsTeamProjectCollection _tpc = new TfsTeamProjectCollection(new Uri("http://server/collection"));
                WorkItemStore _wistore = _tpc.GetService<WorkItemStore>();
                string _teamsStr = ConstructTeamsString(_teamProject, ListTeams(_tpc, _wistore.Projects[_teamProject]));
                string _wiql = string.Format("SELECT [System.Id] FROM WorkItemLinks WHERE ([Source].[System.TeamProject] = '{0}'"+ 
                    "AND ( [Source].[System.WorkItemType] = 'Bug'  OR  [Source].[System.WorkItemType] = 'Product Backlog Item'  OR  [Source].[System.WorkItemType] = 'Feature' ) " + 
                    "AND ( {1} )) " + 
                    "And ([System.Links.LinkType] = 'System.LinkTypes.Hierarchy-Forward') And " + 
                    "([Target].[System.WorkItemType] = 'Task'  OR  [Target].[System.WorkItemType] = 'Product Backlog Item') ORDER BY [System.Id] mode(Recursive)",
                    _teamProject, _teamsStr);
                Query _query = new Query(_wistore, _wiql);
                WorkItemLinkInfo[] _links = _query.RunLinkQuery();
                foreach(WorkItemLinkInfo _link in _links)
                {
                    //process link info item ....
                }
            }
        }
    }
