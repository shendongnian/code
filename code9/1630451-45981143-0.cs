    static int Main(string[] args)
    {
        if (args.Length == 0 || args.Any(a => !a.StartsWith("$/")))
        {
            Console.WriteLine("Removes all explicit permissions and enables inheritance for a subtree.\n"
                            + "Example:  " + Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location) + " $/project/path1 $/project/path2");
            return 3;
        }
    
        WorkspaceInfo wi = Workstation.Current.GetLocalWorkspaceInfo(Environment.CurrentDirectory);
        if (wi == null)
        {
            Console.WriteLine("Can't determine workspace for current directory: " + Environment.CurrentDirectory);
            return 2;
        }
    
        var Tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(wi.ServerUri);
        VersionControlServer VersionControlServer = Tfs.GetService<VersionControlServer>();
    
        Console.WriteLine("Server: {0}  Getting permissions...", wi.ServerUri);
        ItemSecurity[] perms = VersionControlServer.GetPermissions(args, RecursionType.Full);
    
        Console.WriteLine("Will remove explicit permissions from the following items:");
    
        var changes = new List<SecurityChange>();
        foreach (ItemSecurity perm in perms)
        {
            Console.WriteLine("    " + perm.ServerItem);
    
            changes.Add(new InheritanceChange(perm.ServerItem, inherit: true));
            foreach (AccessEntry e in perm.Entries)
            {
                changes.Add(new PermissionChange(perm.ServerItem, e.IdentityName, null, null, PermissionChange.AllItemPermissions));
            }
        }
    
        Console.WriteLine("Enter to confirm:");
        Console.ReadLine();
    
        var successfulchanges = VersionControlServer.SetPermissions(changes.ToArray());
        if (successfulchanges.Length == changes.Count)
        {
            Console.WriteLine("Explicit permissions removed from all items");
            return 0;
        }
        else
        {
            Console.WriteLine("Explicit permissions removed only from:");
            foreach (var c in successfulchanges)
            {
                Console.WriteLine("    " + c.Item);
            }
    
            return 1;
        }
    }
