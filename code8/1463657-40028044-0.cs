    for (int i = 0; i < allItems.Count; ++i)
    {
      PropertyInfo indexProperty = typeof(IList<TProperty>).GetProperty("Item");
      IndexExpression indexExpression = Expression.MakeIndex(
        expression.Body, 
        indexProperty, 
        new Expression[] { Expression.Constant(i) }
      );
      Expression<Func<TModel, TProperty>> lambda = 
        Expression.Lambda<Func<TModel, TProperty>>(
          indexExpression,
          expression.Parameters[0]
      );
                
      MvcHtmlString hidden = htmlHelper.HiddenFor(lambda);
    }
