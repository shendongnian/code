    public static List<int[]> Parse(List<string> list)
    {
        if (list == null)
        {
            throw new ArgumentNullException("list");
            // you can use nameof(list) instead of "list" in newer versions of C#
        }
        List<int[]> result = new List<int[]>();
        // Loop through the entries
        for (int i = 0; i < list.Count; ++i)
        {
            // Be safe and check we don't have a null value
            // I'm just skipping the 'bad' entries for now but
            // you can throw an error, etc.
            if (list[i] == null)
            {
                // do something about this? (an exception of your choosing, etc.)
                continue;
            }
            // split the entry
            string[] entryData = list[i].Split(';');
            // check we have 3 items
            if (entryData.Length != 3)
            {
                // do something about this?
                continue;
            }
            // try to parse each item in turn
            int a;
            int b;
            int c;
            if (!int.TryParse(entryData[0], out a))
            {
                // do something about this?
                continue;
            }
            if (!int.TryParse(entryData[1], out b))
            {
                // do something about this?
                continue;
            }
            if (!int.TryParse(entryData[2], out c))
            {
                // do something about this?
                continue;
            }
            // add to the results list
            result.Add(new int[] { a, b, c });
        }
        // return the result
        return result;
    }
