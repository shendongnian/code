    using (StreamWriter writer = new StreamWriter(@"Metalai.csv"))
    {
        var duplicateChecker = new HashSet<Ring>;
        int numDuplicates = 0;
        writer.WriteLine("Metalai");
        foreach (Ring ring in rings)
        {
            bool noDuplicate = duplicateChecker.Add(ring);
            
            if (noDuplicate)
                writer.WriteLine("{0}", ring.Metalas);
            else
                numDuplicates++;
        }
    }
