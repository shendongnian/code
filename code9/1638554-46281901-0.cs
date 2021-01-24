    public static IEnumerable<int> ListSum(IEnumerable<IEnumerable<int>> ll)
    {
        var resultList = new List<int>();
        var enumerators = ll.Select(l => l.GetEnumerator()).ToArray();
        bool stillResult;
        do
        {
            stillResult = false;
            var sum = 0;
            foreach (var e in enumerators)
            {
                if (e.MoveNext())
                {
                    sum += e.Current;
                    stillResult = true;
                }
            }
            resultList.Add(sum);
        } while (stillResult);
        return resultList;
    }
