    public string[] Split(string input, char splitChar, char groupStart, char groupEnd)
    {
        List<string> splits = new List<string>();
        int startIdx = 0;
        int groupNo = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == splitChar && groupNo == 0)
            {
                splits.Add(input.Substring(startIdx, i - startIdx));
                startIdx = i + 1;
            }
            else if (input[i] == groupStart)
            {
                groupNo++;
            }
            else if (input[i] == groupEnd)
            {
                groupNo = Math.Max(groupNo - 1, 0);
            }
        }
        splits.Add(input.Substring(startIdx, input.Length - startIdx));
        return splits.Where(s => !string.IsNullOrEmpty(s)).ToArray();
    }
