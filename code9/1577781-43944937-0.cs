    public static void MyMethod(params Expression<Func<Subscription, object>>[] fields)
    {
        var memberExpressions = fields
            .Where(f => typeof(MemberExpression).IsAssignableFrom(f.Body.GetType()))
            .Select(f => (MemberExpression)f.Body)
            .ToList();
        if (memberExpressions.Any(ex => 
            ex.Member.MemberType == MemberTypes.Property &&
            ex.Member.Name == "SomeProperty"))
        {
            Console.WriteLine("At least one of the fields expressions passed to this function were x => x.SomeProperty");
        }
    }
