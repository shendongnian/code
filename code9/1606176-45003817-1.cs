    // note that you still require to insert PropertyInfo as a lambda expression here
    public static MvcHtmlString LabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
    {
        var modelType = typeof(TModel);
        var propertyInfo = typeof(System.Reflection.PropertyInfo);
        if (modelType.IsAssignableFrom(propertyInfo))
        {
            var type = expression.Type;
            var tag = new TagHelper("label");
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            tag.MergeAttributes(attributes);
            tag.SetInnerText(type.FullName); // set inner text between label tag
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
        else
        {
            // return another value, e.g. return MvcHtmlString.Empty
        }
    }
