    public static MvcHtmlString LabelFor<PropertyInfo, TValue>(this HtmlHelper<PropertyInfo> html, Expression<Func<PropertyInfo, TValue>> expression)
    {
        var type = expression.Type;
        MvcHtmlString result = new MvcHtmlString(type.FullName);
        return result;
    }
