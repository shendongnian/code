    private static void SaveDataToFile(List<Ring> rings)
    {
        using (StreamWriter writer = new StreamWriter(@"Metalai.csv"))
        {
            List<Ring> results = new List<Ring>();
            writer.WriteLine("Metalai");
            String oldRing = String.empty;
            int duplicates = 0;
            foreach (var ring in rings)
                if (!results.Contains(ring))
            {
                if (ring.Metalas == oldRing)
                {
                    Console.WriteLine("{0}", ring.Metalas);
                    duplicates++;
                }
                else
                {
                    writer.WriteLine("{0}", ring.Metalas);
                    oldRing = ring.Metalas;
                }
            }
        }
    }
