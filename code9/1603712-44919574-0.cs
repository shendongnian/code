    private List <string> SortText(List<string> Names)
    {
        List<int> order = new List<int>();
        List<bool> found = new List<bool>();
        for (int i = 0; i < Names.Count; i++)
        {
            order.Add(0);
            found.Add(false);
        }
        for (int i = 0; i < Names.Count - 1; i++)
        {
            string test = Names[i];
            int pos = 0;
            for (int j = 0; j < Names.Count; j++)
            {
                if (i == j)
                {
                    continue;
                }
                string comp = Names[j];
                pos += isHigher(test, comp);
            }
            while (found[pos] == true)
            {
                pos++;
            }
            order[i] = pos;
            found[pos] = true;
        }
        //last one is the position missing in found
        for (int i = 0; i < Names.Count; i++)
        {
            if (!found[i])
            {
                order[Names.Count - 1] = i;
            } 
        }
        List<string> sorted = new List<string>();
        for (int i = 0; i < Names.Count; i++)
        {
            for (int j = 0; j < Names.Count; j++)
            {
                if (order[j] == i)
                {
                    sorted.Add(Names[j]);
                    break;
                }
            }
        }
        return sorted;
    }
    private int isHigher(string test, string comp)
    {
        char[] arTest = test.ToArray();
        char[] arComp = comp.ToArray();
        for (int i = 0; i < arTest.Length; i++)
        {
            if (i == arComp.Length)
            {
                return 1;
            }
            if (arTest[i] > arComp[i])
            {
                return 1;
            }
            else if (arTest[i] < arComp[i])
            {
                return 0;
            }
        }
        return 0;
    }
