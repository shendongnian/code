    public static class TableHelper
    {
        public static MvcHtmlString TableSpanFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
        {
            // Get the model metadata
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            // Get the fully qualified name of the property
            string propertyName = ExpressionHelper.GetExpressionText(expression);
            TagBuilder span = new TagBuilder("span");
            span.AddCssClass(propertyName); // or span.MergeAttribute("data-key", propertyName);
            span.InnerHtml = metadata.Model.ToString();
            return MvcHtmlString.Create(span.ToString());
            // To include the enclosing <td> element as well
            TagBuilder cell = new TagBuilder("td");
            cell.InnerHtml = span.ToString();
            return MvcHtmlString.Create(cell.ToString());
        }
    }
