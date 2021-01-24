    var workspace = new DirectoryInfo("MyWorkspace");
    if (workspace.Exists)
    {
        workspace.Delete();
    }
    workspace.Create();
    var limit = 214643507; // TODO : find here the maximum acceptable value for the hashset size. I am not sure this one will work.
    var buffer = new HashSet<string>();
    ulong i = 0;
    int j = 0;
    while (i <= ulong.MaxValue)
    {
        var result = YourSuperAlgorythm(i);
        // Check the result with current results
        if (buffer.Contains(result))
        {
            throw new Exception("Failure !");
        }
        // Check the result with older results
        foreach (var file in workspace.GetFiles())
        {
            var content = new HashSet<string>(File.ReadAllText(file.FullName).Split(';'));
            if (content.Contains(result))
            {
                throw new Exception("Failure !");
            }
        }
        buffer[j] = result;
        i++;
        j++;
        if (j == arrayLimit)
        {
            j = 0;
            var file = Path.GetRandomFileName();
            File.WriteAllText(Path.Combine(workspace.FullName, file), String.Join(";", buffer));
            buffer = new HashSet<string>();
        }
    }
