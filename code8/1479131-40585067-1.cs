    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    
    namespace APPI
    {
        class Program
        {
            static void Main(string[] args)
            {
                string url = "http://xxx.xxx.xxx.xxx:8080/tfs/DefaultCollection";
                TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(new Uri(url));
                WorkItemStore wis = ttpc.GetService<WorkItemStore>();
                VersionControlServer vcs = ttpc.GetService<VersionControlServer>();
                int wid = 82;
                int cid = 332;
                WorkItem wi = wis.GetWorkItem(wid);
                Changeset cs = vcs.GetChangeset(cid);
                ExternalLink el = new ExternalLink(wis.RegisteredLinkTypes["Fixed in Changeset"], cs.ArtifactUri.AbsoluteUri);
                wi.Links.Add(el);
                wi.Save();     
            }
        }
    }
