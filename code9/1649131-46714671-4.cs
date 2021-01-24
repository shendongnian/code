    public static IEnumerable<Attribute> GetSupportedVerbsForAction<T>(
        Expression<Func<T, IActionResult>> expression)
        where T : Controller
    {
        //only consider a list of attributes
        var typesToCheck = new[] { typeof(HttpGetAttribute), typeof(HttpPostAttribute),
            typeof(HttpPutAttribute), typeof(HttpDeleteAttribute), typeof(HttpPatchAttribute)};
        var method = ((MethodCallExpression)expression.Body).Method;
        var matchingAttributes = typesToCheck
            .Where(x => method.IsDefined(x))
            .ToList();
        //if the method doesn't have any of the attributes we're looking for,
        //assume that it does all verbs
        if (!matchingAttributes.Any())
            foreach(var verb in typesToCheck)
                yield return verb;
        //else, return all the attributes we did find
        foreach (var foundAttr in matchingAttributes)
        {
            yield return method.GetCustomAttribute(foundAttr);
        }
    }
