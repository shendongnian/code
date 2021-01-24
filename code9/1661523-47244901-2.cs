    for (int i = 0; i < lines.Length; i++)
    {
        foreach (string stringToFind in stringsToFind)
        {
            if (lines[i].Contains(stringToFind))
            {
                // We use i+1 for line number to show that in a 'human' format.
                Console.WriteLine(string.Format("Found {0} at line {1}", stringToFind, (i+1)));
            }
        }
    }
