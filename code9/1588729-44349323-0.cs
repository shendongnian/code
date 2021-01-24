    public static void BalanceItemsBetweenLists<T>(
        IEnumerable<T> input, 
        IEnumerable<List<T>> targets)
    {
        var inputArray = input as T[] ?? input.ToArray();
        var targetArray = targets as List<T>[] ?? targets.ToArray();
        var currentTargetIndex = 0;
        foreach (var item in inputArray)
        {
            targetArray[currentTargetIndex].Add(item);
            currentTargetIndex++;
            if (currentTargetIndex == targetArray.Length) currentTargetIndex = 0;
        }
    }
    [TestMethod]
    public void BalancesListsWhenAddingItems()
    {
        var source = Enumerable.Range(1, 11);
        var targets = Enumerable.Range(1, 8).Select(n => new List<int>()).ToArray();
        ListBalancer.BalanceItemsBetweenLists(source,targets);
            
        Assert.AreEqual(2, targets[0].Count);
        Assert.AreEqual(2, targets[1].Count);
        Assert.AreEqual(2, targets[2].Count);
        Assert.AreEqual(1, targets[3].Count);
    }
