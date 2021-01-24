    List<string> finalResults = new List<string>();
    List<int> idsEncountered = new List<int>();
    foreach (string dir in results)
    {
        int id = int.Parse(dir.Substring(s.Length - 5));
        if (!idsEncountered.Contains(id))
        {
            idsEncountered.Add(id);
            finalResults.Add(dir);
        }
    }
