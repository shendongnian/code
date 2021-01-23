    //done with int there, but you could do with the desired type
    public static IHtmlString DisplayConditionalPercent<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, int>> expression, int minimalDisplayValue = 0)
    {
        int value;
        var displayValue = helper.DisplayFor(expression);
        if (int.TryParse(displayValue.ToString(), out value) && value > minimalDisplayValue)
            return MvcHtmlString.Create(displayValue + " %");
        return null;
    }
