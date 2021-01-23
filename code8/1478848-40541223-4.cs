    private static List<Tuple<string, string>> GenerateTwoElementSetFromList(List<string> list)
    {
        List<Tuple<string, string>> set = new List<Tuple<string, string>>();
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                set.Add(new Tuple<string, string>(list[i], list[j]));
            }
        }
        return set;
    }
