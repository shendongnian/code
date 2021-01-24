    public static void Main(string[] args)
    {
        var files = new Dictionary<string, string>();
        foreach (var file in Directory.GetFiles("c:\\", "*.png"))
        {
            files.Add(file, CalculateHash(file));
        }
        var duplicates = files.GroupBy(item => item.Value).Where(group => group.Count() > 1);
    }
    private static string CalculateHash(string file)
    {
        using (var stream = File.OpenRead(file))
        {
            var sha = new SHA256Managed();
            var checksum = sha.ComputeHash(stream);
            return BitConverter.ToString(checksum).Replace("-", String.Empty);
        }
    }
