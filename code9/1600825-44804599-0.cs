    var twoLetterGroups = File.ReadLines(load.FileName)
       .Where(l => l.Length >= 2)
       .GroupBy(l => l.Substring(0, 2), StringComparer.InvariantCultureIgnoreCase)
       .Select(g => new { FirstTwoLetters = g.Key, Lines = g.ToArray()})
       .ToArray();
    ListBox[] listboxes = Enumerable.Range(0, twoLetterGroups.Length).Select(i => new ListBox()).ToArray();
    for (int i = 0; i < twoLetterGroups.Length; i++)
    {
        listboxes[i].Items.AddRange(twoLetterGroups[i].Lines);
    }
    // add listboxes to form
