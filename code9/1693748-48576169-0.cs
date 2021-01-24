    static void Main(string[] args)
            {
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri("http://server:8080/tfs/DefaultCollection"));
                new System.Net.NetworkCredential("username", "password");
                tpc.EnsureAuthenticated();
                VersionControlServer vcs = tpc.GetService<VersionControlServer>();
    
                int cid = 376;
    
                //List<IChangesetSummary> changeSets = InformationNodeConverters.GetAssociatedChangesets(build);
                IEnumerable<Change> changes = vcs.GetChangesForChangeset(cid, false, Int32.MaxValue, null, null, true);
    
                foreach (Change change in changes)
                {
                    if ((change.ChangeType & ChangeType.Merge) == 0) continue;
                    foreach (var m in change.MergeSources)
                    {
                        Console.WriteLine("{0} {1} {2} {3}", change.Item.ChangesetId, m.ServerItem, m.VersionFrom, m.VersionTo);
                    }                   
                }
                Console.ReadLine();
            }
