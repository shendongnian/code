    var toDelete = new HashSet<string>();
    var names = File.ReadAllLines("firstNames.txt");
    foreach (string name in names) {
        var tempName = name.Split('|')[0];
        toDelete.UnionWith(
            // Length constraint removes self-matches
            names.Where(t => t.Length > name.Length && t.Contains(tempName))
        );
    }
    File.WriteAllLines("result.txt", names.Where(name => !toDelete.Contains(name)));
