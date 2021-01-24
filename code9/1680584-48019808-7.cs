    while (!sr.EndOfStream)
    {
        string[] rows = sr.ReadLine().Split(sep);
        for (int i = 0; i < rows.Length; i++)
        {
            //I simplified your checks, this is safer and simplier.
            if (string.IsNullOrWhiteSpace(rows[i]) || rows[i] == "NA" || rows[i] == "NULL")
            {
                rows[i] = null;
            }
        }
        // another logic ...
    }
