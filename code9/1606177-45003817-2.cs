    public static MvcHtmlString PropertyLabelFor<TModel>(this HtmlHelper<TModel> html, PropertyInfo propertyInfo, object htmlAttributes)
    {
        var type = propertyInfo.GetType();
        var tag = new TagHelper("label");
        var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
        tag.MergeAttributes(attributes);
        tag.SetInnerText(type.FullName); // set inner text between label tag
        return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
    }
