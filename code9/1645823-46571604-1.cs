    public static IEnumerable<MemberInfo> GetProperties(this Expression expression)
    {
        var visitor = new PropertySearchVisitor();
        visitor.Visit(expression);
        return visitor.Properties;
    }
    public static IEnumerable<string> GetPropertyNames(this Expression expression)
    {
        var visitor = new PropertySearchVisitor();
        visitor.Visit(expression);
        return visitor.Properties.Select(property => property.Name);
    }
