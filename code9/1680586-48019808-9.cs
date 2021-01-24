    string[] lines = File.ReadAllLines("test.txt");
    Parallel.For(0, lines.Length, x =>
    {
        string[] rows = lines[x].Split(sep);
        for (int i = 0; i < rows.Length; i++)
        {
            if (string.IsNullOrWhiteSpace(rows[i]) || rows[i] == "NA" || rows[i] == "NULL")
            {
                rows[i] = null;
            }
        }
    });
