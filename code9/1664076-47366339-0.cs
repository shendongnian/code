    // QueryVisitor.cs : 152
    // Contains (String): x.Name.Contains("auricio")
    else if (method == "Contains" && type == typeof(string))
    {
        var value = this.VisitValue(met.Arguments[0], null);
        return Query.Contains(this.GetField(met.Object, prefix), value);
    }
    // Contains (Enumerable): x.ListNumber.Contains(2)
    else if (method == "Contains" && type == typeof(Enumerable))
    {
        var field = this.GetField(met.Arguments[0], prefix);
        var value = this.VisitValue(met.Arguments[1], null);
        return Query.EQ(field, value);
    }
