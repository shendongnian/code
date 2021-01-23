    int inx = 0;
    var fInfo = new FileInfo(filename); 
    var lines = File.ReadAllLines(fInfo.FullName);
    foreach (var groups in lines.GroupBy(x => inx++ / (lines.Length / 4)))
    {
        File.WriteAllLines($"{fInfo.DirectoryName}\\{fInfo.Name}_{groups.Key}{fInfo.Extension}", groups);
    }
