    public void JoinSplitCellLines()
    {
        for (var i = 0; i < list.Count; i++)
        {
            if (list[i].StartsWith("\"", StringComparison.CurrentCultureIgnoreCase))
            {
                if (!list[i].EndsWith("\"", StringComparison.CurrentCultureIgnoreCase))
                {
                    for (var j = i + 1; j < list.Count; j++)
                    {
                        if (string.IsNullOrWhiteSpace(list[j]))
                        {
                            list[i] = list[i] + list[j + 1];
                            list.RemoveRange(i, j - i);
                            break;
                        }
                    }
                }
            }
        }
    }
