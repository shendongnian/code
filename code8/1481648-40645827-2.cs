    public static IHtmlString MyEditorFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, object ViewData, bool disabled = false, bool visible = true)
    {
        var member = expression.Body as MemberExpression;
        var stringLength = member.Member.GetCustomAttributes(typeof(StringLengthAttribute), false).FirstOrDefault() as StringLengthAttribute;
        RouteValueDictionary viewData =  HtmlHelper.AnonymousObjectToHtmlAttributes(ViewData);
        RouteValueDictionary htmlAttributes = HtmlHelper.AnonymousObjectToHtmlAttributes(viewData["htmlAttributes"]);
        if (stringLength != null)
        {
            htmlAttributes.Add("maxlength", stringLength.MaximumLength);
        }
        return htmlHelper.EditorFor(expression, htmlAttributes); // use custom HTML attributes here
    }
