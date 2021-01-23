    public static IHtmlString MyTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, bool disabled)
    {
        IDictionary<string, object> attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
        if (disabled)
        {
            attrs.Add("disabled", "disabled");
        }
        return htmlHelper.TextBoxFor(expression, attrs);
    }
