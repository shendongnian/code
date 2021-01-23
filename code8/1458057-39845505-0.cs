     NetworkCredential cred = new NetworkCredential("[account name]", "[person access token]");
                 TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri("https://[xxx].visualstudio.com"), cred);
                tpc.EnsureAuthenticated();
                VersionControlServer versionControl = tpc.GetService<VersionControlServer>();
    Workspace workspace = versionControl.CreateWorkspace("TestWorkspace", versionControl.AuthorizedUser);
    try
                {
                    String localDir = @"c:\temp\BasicSccExample";
                    //Console.WriteLine("\r\n--- Create a mapping: {0} -> {1}", args[1], localDir); 
                    workspace.Map("$/Agile2015/APIFolder", localDir);
    
                 
                    workspace.Get();
    
                    Console.WriteLine("\r\n--- Create a file.");
                    topDir = Path.Combine(workspace.Folders[0].LocalItem, "sub");
                    Directory.CreateDirectory(topDir);
                    String fileName = Path.Combine(topDir, "basic.txt");
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        sw.WriteLine("revision 1 of basic.txt");
                    }
    
                    Console.WriteLine("\r\n--- Now add everything.\r\n");
                    workspace.PendAdd(topDir, true);
    
                    Console.WriteLine("\r\n--- Show our pending changes.\r\n");
                    PendingChange[] pendingChanges = workspace.GetPendingChanges();
                    Console.WriteLine("  Your current pending changes:");
                    foreach (PendingChange pendingChange in pendingChanges)
                    {
                        Console.WriteLine("    path: " + pendingChange.LocalItem +
                                          ", change: " + PendingChange.GetLocalizedStringForChangeType(pendingChange.ChangeType));
                    }
    
                    Console.WriteLine("\r\n--- Checkin the items we added.\r\n");
                    int changesetNumber = workspace.CheckIn(pendingChanges, "Sample changes");
                    }
                
