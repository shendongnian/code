    private IEnumerable<string> _GetUniqueTeamProjects(Changeset changeset)
        {
            //We can have many changes in files in differentes TeamProjects within the same changeset
            HashSet<string> teamProjects = new HashSet<string>();
            foreach (var ch in changeset.Changes)
            {
                //Get TeamProject using available repository access and change paths on server side.
                var tp = ch.Item.VersionControlServer.GetTeamProjectForServerPath(ch.Item.ServerItem);
                //Let the HashTable handle the unique value
                teamProjects.Add(tp.Name);
            }
            return teamProjects;
        }
