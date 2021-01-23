    public static MvcHtmlString HiddenForEach<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IList<TProperty>>> expression)
    {
        var sb = new StringBuilder();
        IList<TProperty> allItems = expression.Compile().Invoke(htmlHelper.ViewData.Model);
        for (int i = 0; i < allItems.Count; ++i)
        {
			var getListItemExpr = Expression.Call(expression.Body, typeof(IList<TProperty>).GetMethod("get_Item"), Expression.Constant(i));
			var lambdaWithIndex = Expression.Lambda<Func<TModel, TProperty>>(getListItemExpr, expression.Parameters);
			sb.Append(htmlHelper.HiddenFor(lambdaWithIndex).ToHtmlString());
        }
        return MvcHtmlString.Create(sb.ToString())
    }
