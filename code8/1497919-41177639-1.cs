    NetworkCredential cred = new NetworkCredential("[user name]", "[password]", "[domain]");
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri("[collection URL"), cred);
                tpc.EnsureAuthenticated();
                WorkItemStore wis = tpc.GetService(typeof(WorkItemStore)) as WorkItemStore;
     QueryHierarchy queryRoot = wis.Projects["[team project]"].QueryHierarchy;
                QueryFolder queryFolder = queryRoot["Shared Queries"] as QueryFolder;
                QueryDefinition qd = queryFolder["PBIS"] as QueryDefinition;
                string tt = qd.QueryText;
