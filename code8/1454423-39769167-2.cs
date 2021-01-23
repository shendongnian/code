	int? MethodToRefactor<T>(EfContext context, IEnumerable<Expression<Func<T, string>>> searchFields, IEnumerable<string> someCollection, string[] moreParams)
        where T : class, IEntity
    {
        int? keyValue = null;
        foreach (var itemDetail in someCollection)
        {
            string refText = GetRefTextBySource(itemDetail, moreParams);
            if (searchFields.Any())
            {
                var filter = searchFields.Skip(1).Aggregate(EqualsValue(searchFields.First(), refText), (e1, e2) => CombineWithOr(e1, EqualsValue(e2, refText)));
				var entity = context.Set<T>().FirstOrDefault(filter);
				if (entity != null)
				{
					keyValue = entity.Key;
				}
				if (... some condition ...)
					break;
            }
        }
        return keyValue;
    }
    private Expression<Func<T, bool>> EqualsValue<T>(Expression<Func<T, string>> propertyExpression, string strValue)
    {
        var valueAsParam = new {Value = strValue}; // this is just to ensure that your strValue will be an sql parameter, and not a constant in the sql
		     // this will speed up further calls by allowing the server to reuse a previously calculated query plan
		     // this is a trick for ef, if you use something else, you can maybe skip this
        return Expression.Lambda<Func<T, bool>>(
			Expression.Equal(propertyExpression.Body, Expression.MakeMemberAccess(Expression.Constant(valueAsParam), valueAsParam.GetType().GetProperty("Value"))), 
			propertyExpression.Parameters); // here you can cache the property info
	}
	private class ParamReplacer : ExpressionVisitor // this i guess you might have already
	{
		private ParameterExpression NewParam {get;set;}
		public ParamReplacer(ParameterExpression newParam)
		{
			NewParam = newParam;
		}
		protected override Expression VisitParameter(ParameterExpression expression)
		{
			return NewParam;
		}
	}
	
	private Expression<Func<T, bool>> CombineWithOr<T>(Expression<Func<T, bool>> e1, Expression<Func<T, bool>> e2) // this is also found in many helper libraries
	{
		return Expression.Lambda<Func<T, bool>>(Expression.Or(e1.Body, new ParamReplacer(e1.Parameters.Single()).VisitAndConvert(e2.Body, MethodBase.GetCurrentMethod().Name)), e1.Parameters);
	}
