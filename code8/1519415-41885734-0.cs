    public static MvcHtmlString CheckBoxListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> items)
    {
        if (items == null)
        {
            throw new ArgumentException("...");
        }
        var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
        var model = metadata.Model as IEnumerable<string>;
        if (model == null)
        {
            throw new ArgumentException("...");
        }
        // Get the property name
        var name = ExpressionHelper.GetExpressionText(expression);
        // Get the prefix in case using a EditorTemplate for a nested property
        string prefix = htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix;
        if (!String.IsNullOrEmpty(prefix))
        {
            name = String.Format("{0}.{1}", prefix, name);
        }
        StringBuilder html = new StringBuilder();
        foreach (var item in items)
        {
            StringBuilder innerHtml = new StringBuilder();
            TagBuilder checkbox = new TagBuilder("input");
            checkbox.MergeAttribute("type", "checkbox");
            checkbox.MergeAttribute("name", name);
            checkbox.MergeAttribute("value", item.Value);
            if (model.Contains(item.Value))
            {
                checkbox.MergeAttribute("checked", "checked");
            }
            innerHtml.Append(checkbox.ToString());
            TagBuilder text = new TagBuilder("span");
            text.InnerHtml = item.Text;
            innerHtml.Append(text.ToString());
            TagBuilder label = new TagBuilder("label");
            label.InnerHtml = innerHtml.ToString();
            TagBuilder li = new TagBuilder("li");
            li.AddCssClass("checkbox");
            li.InnerHtml = label.ToString();
            html.Append(li);
        }
        TagBuilder ul = new TagBuilder("ul");
        ul.InnerHtml = html.ToString();
        return MvcHtmlString.Create(ul.ToString());
    }
