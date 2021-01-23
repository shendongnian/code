    public static IHtmlString CustomEditorFor<TModel, TProp>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProp>> property)
    {
        var name = ExpressionHelper.GetExpressionText(property);
        var metadata = ModelMetadata.FromLambdaExpression(property, helper.ViewData);
        var formatString = metadata.DisplayFormatString;
        var watermark = metadata.Watermark;
        StringBuilder html = new StringBuilder();
        html.Append(helper.TextBoxFor(property, formatString, new { @class = "form-control", placeholder = watermark }));
        html.Append(helper.ValidationMessageFor(property));
        TagBuilder container = new TagBuilder("div");
        container.AddCssClass("col-md-10");
        container.InnerHtml = html.ToString();
        html = new StringBuilder();
        html.Append(helper.LabelFor(property));
        html.Append(container.ToString());
        container = new TagBuilder("div");
        container.AddCssClass("form-group");
        container.InnerHtml = html.ToString();
        return MvcHtmlString.Create(container.ToString());   
    }
    
