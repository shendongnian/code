    public static bool AreEqual<T>(IList<T> list1, IList<T> list2)
    {
        if (list1?.Count != list2?.Count)
            return false;
    
        // order does not matter. Remove OrderBy, if it matters
        // return list1.OrderBy(_ => _).SequenceEqual(list2.OrderBy(_ => _));
        return list1.SequenceEqual(list2);
    }
    
    public static bool AreEqualListOfLists<T>(IList<List<T>> lists1, IList<List<T>> lists2)
    {
        return lists1.All(innerList1 => lists2.Any(innerList2 => AreEqual(innerList1, innerList2)));
    }
    
    static void Main(string[] args)
    {
        var expected = new List<List<string>>
        {
            new List<string> {"123456", "25.6", "15", "b"},
            new List<string> {"123457", "3107450.82", "1", "bcdef"},
            new List<string> {"123458", "0.01", "900000", "-fgehk"}
        };
    
        var actual = new List<List<string>>
        {
            new List<string> {"123456", "25.6", "15", "b"},
            new List<string> {"123457", "3107450.82", "1", "bcdef"},
            new List<string> {"123458", "0.01", "900000", "-fgehk"}
        };
    
        var areEqual = AreEqualListOfLists(expected, actual);
    }
