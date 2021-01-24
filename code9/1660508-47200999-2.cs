    private void CleanUpCSV(string path)
    {
        var rows = File.ReadAllLines(path).Select(x => x.Split(','));
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            foreach (var row in rows.Where(s => s[0] == "Test"))
            {
                writer.WriteLine(row);
            }
        }
    }
