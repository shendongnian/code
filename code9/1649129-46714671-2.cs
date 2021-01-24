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
        //assume that it's a GET call
        if (!matchingAttributes.Any())
            yield return new HttpGetAttribute();
        //else, return all the attributes we did find
        foreach (var foundAttr in matchingAttributes)
        {
            yield return method.GetCustomAttribute(foundAttr);
        }
    }
