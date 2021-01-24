    using System;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.VersionControl.Client;
    
    namespace RenameBranch
    {
        class Program
        {
            static void Main(string[] args)
            {
                string oldPath = @"E:\andy\0418Scrum\web0418-0823";
                string newPath = @"E:\andy\0418Scrum\web0418-1020";
                string collection = @"http://server:8080/tfs/DefaultCollection";
                var tfsServer = new Uri(collection);
                var tpc = new TfsTeamProjectCollection(tfsServer);
                var vcs = tpc.GetService<VersionControlServer>();
    
                Workspace workspace = vcs.GetWorkspace("YourWorkspaceName", vcs.AuthorizedUser);
    
                workspace.PendRename(oldPath, newPath);
            }
        }
    }
