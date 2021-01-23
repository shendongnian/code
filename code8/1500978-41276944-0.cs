    TfsTeamProjectCollection collection = new TfsTeamProjectCollection(new Uri("[collection URL]"));
    
                collection.EnsureAuthenticated();
                VersionControlServer vcs = collection.GetService<VersionControlServer>(); 
                var pendingSets = vcs.QueryPendingSets(new string[] { "[server path]" }, RecursionType.OneLevel, null, null);
                foreach (PendingSet changeset in pendingSets)
                {
                    foreach (PendingChange change in changeset.PendingChanges)
                    {
                        if(change.IsLock)
                        {
                            Console.WriteLine("Lock level:" + change.LockLevel);
                            Console.WriteLine("Locked By:" + changeset.OwnerName);
                            Console.WriteLine("Time:" + change.CreationDate);
                        }
                    }
                }
