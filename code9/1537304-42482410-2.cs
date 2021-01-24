    private static IEnumerable<NonEqualProperty> CompareCollection<T>(IEnumerable<T> firstColl, IEnumerable<T> secondColl) {
        var list = new List<NonEqualProperty>();
        // Do the comparison
        return list;
    }
    private static MethodInfo CompareCollectionMethod = typeof(Program).GetMethod("CompareCollection", BindingFlags.Static | BindingFlags.NonPublic);
