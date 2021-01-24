    NetworkCredential cred1 = new NetworkCredential("alternate credential username", "alternate credential password");
    TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(new Uri("https://account.visualstudio.com"), cred1);
    VersionControlServer versionControl = tpc.GetService<VersionControlServer>();
    Workspace ws = versionControl.GetWorkspace(@"C:\Users\TFSTest\Source\Workspaces\G11\TryTFVC");//older path
    WorkingFolder wf = new WorkingFolder("$/TryTFVC", @"C:\Users\TFSTest\Source\Workspaces\G1\1");
    ws.CreateMapping(wf); //map with new path
    ws.Get();
    
    GetStatus status = ws.Get();
    Console.Write("Conflicts from checkout: ");
    Console.WriteLine(status.NumConflicts);
