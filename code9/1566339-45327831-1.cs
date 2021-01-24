    public static HashSet<string> GetNamesFromRangeQuery(string multipleIds)
    {
        multipleIds = multipleIds.ToUpper().Replace(" ", "");
    
        HashSet<string> inSet = new HashSet<string>();
    
        string[] parts = multipleIds.Split(new[] { ";" }, StringSplitOptions.None);
    
        foreach (string part in parts)
        {
            Regex rgx = new Regex(@"^M([0 - 9] +)C([0 - 9] +)$");
            Regex rgxTwo = new Regex(@"^M([0-9]+)C([0-9]+)-M([0-9]+)C([0-9]+)$");
            Regex rgxThree = new Regex(@"^[0-9]+$");
            Regex rgxFour = new Regex(@"^([0-9]+)-([0-9]+)$");
    
            if (rgx.IsMatch(part))
            {
                inSet.Add(part);
            }
            else if (rgxTwo.IsMatch(part))
            {
                string[] fromTo = part.Split(new[] { "-" }, StringSplitOptions.None);
                int mFrom = int.Parse(fromTo[0].Substring(1, fromTo[0].IndexOf("C")));
                int mTo = int.Parse(fromTo[1].Substring(1, fromTo[1].IndexOf("C")));
    
                int cFrom = int.Parse(fromTo[0].Substring(fromTo[0].LastIndexOf("C") + 1));
                int cTo = int.Parse(fromTo[1].Substring(fromTo[1].LastIndexOf("C") + 1));
    
                for (int i = mFrom; i <= mTo; i++)
                {
                    for (int j = cFrom; j <= cTo; j++)
                    {
                        inSet.Add("M" + i + "C" + j);
                    }
                }
            }
            else if (rgxThree.IsMatch(part))
            {
                inSet.Add(part);
            }
            else if (rgxFour.IsMatch(part)
    
                {
                string[] fromTo = part.Split(new[] { "-" }, StringSplitOptions.None);
                int from = int.Parse(fromTo[0]);
                int to = int.Parse(fromTo[1]);
    
                for (int i = from; i <= to; i++)
                {
                    inSet.Add(i.ToString());
                }
            }
            else
            {
                inSet.Add(part);
            }
        }
    
        return inSet;
    }
