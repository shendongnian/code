    int[] arr = new[] { 1,1,1,2,2,2,3,3,3,4,4,4,5,5,5 };
    var orderList = arr.OrderBy(x => x).Distinct().ToArray();
    var refList = arr.GroupBy(x => x).ToDictionary(k => k.Key, v => v.Count());
    var result = new List<int>();
    int i = 0;
    while (result.Count < arr.Length)
    {
        if (refList.Values.Sum() == 0)
            break;
        if (refList[orderList[i]] > 0)
        {
            result.Add(orderList[i]);
            refList[orderList[i]]--;
        }
        i++;
        if (i >= orderList.Length)
            i = 0;
    }
    // Result: [1,2,3,4,5,1,2,3,4,5,1,2,3,4,5]
