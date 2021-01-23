    string memberPath = ...; // e.g. "Property2.ChildProperty2"
    var parameter = Expression.Parameter(typeof(T), "x");
    Expression result;
    if (memberPath.IndexOf('.') < 0)
    	result = Expression.PropertyOrField(parameter, memberPath);
    else
    {
    	var memberNames = memberPath.Split('.');
    	var members = new Expression[memberNames.Length];
    	for (int i = 0; i < memberNames.Length; i++)
    		members[i] = Expression.PropertyOrField(i > 0 ? members[i - 1] : parameter, memberNames[i]);
    	result = members[members.Length - 1];
    	// For non nullable value types, promote the result into the corresponding nullable type
    	if (result.Type.IsValueType && Nullable.GetUnderlyingType(result.Type) == null)
    		result = Expression.Convert(result, typeof(Nullable<>).MakeGenericType(result.Type));
    	var nullResult = Expression.Constant(null, result.Type);
    	for (int i = members.Length - 2; i >= 0; i--)
    	{
    		result = Expression.Condition(
    			Expression.NotEqual(members[i], Expression.Constant(null)),
    			result, nullResult);
    	}
    }
