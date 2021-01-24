    static List<List<string>> GetGroups(List<string> masterList, int groupCount)
    {
        var groups = new List<List<string>>();
        // Argument validation. All of these conditions should be true.
        if (masterList != null && groupCount > 0 && groupCount <= masterList.Count)
        {
            var minGroupSize = masterList.Count / groupCount;
            var extraItems = masterList.Count % groupCount;
            for (int i = 0; i < groupCount; i++)
            {
                groups.Add(masterList.Skip(i * minGroupSize).Take(minGroupSize).ToList());
                if (i < extraItems)
                {
                    groups[i].Add(masterList[masterList.Count - 1 - i]);
                }
            }
        }
        return groups;
    }
