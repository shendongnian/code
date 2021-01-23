    public static bool CompareLists<T1, T2>(IEnumerable<T1> list1, IEnumerable<T2> list2, List<DuplicateExpression> DuplicateExpression)
    {
        var fields = DuplicateExpression.Select(x => x.ExpressionName).ToArray();
        return list1.GroupJoin(list2, fields, (x, match) => match).All(match => match.Any())
            && list2.GroupJoin(list1, fields, (x, match) => match).All(match => match.Any());
    }
