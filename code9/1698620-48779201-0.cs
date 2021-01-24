    using Microsoft.TeamFoundation.Client;
    using System;
    using Microsoft.TeamFoundation.VersionControl.Client;
    
    namespace GetLatest
    {
        class Program
        {
            static void Main(string[] args)
            {
                TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri("http://tfsserver:8080/tfs/TeamProjectCollection"));
                var versioncontrols = tfs.GetService<VersionControlServer>();
                var workspace = versioncontrols.GetWorkspace("test", versioncontrols.AuthorizedUser);
                workspace.Get();
    
            }
        }
    }
