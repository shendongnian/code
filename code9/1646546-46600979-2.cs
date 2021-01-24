    private static void SaveDataToFile(List<Ring> rings)
    {
        var metalasLookup = rings.ToLookup(r => r.Metalas);
        using (StreamWriter writer = new StreamWriter(@"Metalai.csv"))
        {
            writer.WriteLine("Metalai");
            foreach (var metalasGroups in metalasLookup)
            {
                int count = metalasGroups.Count();
                string = line $"{metalasGroups.Key},{(count == 0 ? "" : count.ToString())}";
                writer.WriteLine(line);
            }
        }
    }
