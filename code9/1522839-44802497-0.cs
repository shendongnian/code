    private IEnumerable<string> _GetUniqueTeamProjects(Changeset changeset)
        {
            HashSet<string> teamProjects = new HashSet<string>();
            foreach (var ch in changeset.Changes)
            {
                var tp = ch.Item.VersionControlServer.GetTeamProjectForServerPath(ch.Item.ServerItem);
                teamProjects.Add(tp.Name);
            }
            return teamProjects;
        }
