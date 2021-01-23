    var path = @"C:\Users\";
    var name = "samy jack sammour";
    
    Func<IEnumerable<string>, IEnumerable<string>> permutate = null;
    permutate = items =>
    	items.Count() > 1 ?
    		items.SelectMany(
    			(_, ndx1) => permutate(items.Where((__, ndx2) => ndx1 != ndx2)),
    			(item1, item2) => item1 + (item2.StartsWith(",") ? "" : " ") + item2) :
    		items;
    
    var names = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Concat(new[] { "," }).ToArray();
    var dirs = new HashSet<string>(permutate(names).Where(n => !n.StartsWith(",") && !n.EndsWith(",")), StringComparer.OrdinalIgnoreCase);
    if (new DirectoryInfo(path).EnumerateDirectories().Any(dir => dirs.Contains(dir.Name) && dir.EnumerateFiles("*.pptx").Any()))
    	MessageBox.Show("true");
