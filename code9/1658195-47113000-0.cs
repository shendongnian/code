    [HttpGet]
    public IHttpActionResult Get(ODataQueryOptions<Model1> options)
    {
        var result = modelRepository.List();
        Action<ICollection<Model1>> postAction = collection => { Console.WriteLine("Post Action"); };
        return ApplyOdataOptionsAndCallPostAction(result, options, postAction);
    }
    
    private IHttpActionResult ApplyOdataOptionsAndCallPostAction<T>(
        IQueryable<T> baseQuery, 
        ODataQueryOptions<T> options, 
        Action<ICollection<T>> postAction)
        where T : class
    {
        var queryable = options.ApplyTo(baseQuery);
        var itemType = queryable.GetType().GetGenericArguments().First();
        var evaluatedQuery = ToTypedList(queryable, itemType);
        var dtos = ExtractAllDtoObjects<T>(evaluatedQuery).ToList();
        postAction(dtos)
                    
        return Ok(evaluatedQuery, evaluatedQuery.GetType());
    }
    
    private static IList ToTypedList(IEnumerable self, Type innerType)
    {
        var methodInfo = typeof(Enumerable).GetMethod(nameof(Enumerable.ToList));
        var genericMethod = methodInfo.MakeGenericMethod(innerType);
        return genericMethod.Invoke(null, new object[]
        {
            self
        }) as IList;
    }
    private IEnumerable<T> ExtractAllDtoObjects<T>(IEnumerable enumerable)
        where T : class
    {
        foreach (var item in enumerable)
        {
            if (item is T typetItem)
            {
                yield return typetItem;
            }
            else
            {
                var result = TryExtractTFromWrapper<T>(item);
                if (result != null)
                {
                    yield return result;
                }
            }
        }
    }
    private static T TryExtractTFromWrapper<T>(object item)
        where T : class
    {
        if (item is ISelectExpandWrapper wrapper)
        {
            var property = item.GetType().GetProperty("Instance");
            var instance = property.GetValue(item);
            if (instance is T val)
            {
                return val;
            }
        }
        return null;
    }
    private IHttpActionResult Ok(object content, Type type)
    {
        var resultType = typeof(OkNegotiatedContentResult<>).MakeGenericType(type);
        return Activator.CreateInstance(resultType, content, this) as IHttpActionResult;
    }
