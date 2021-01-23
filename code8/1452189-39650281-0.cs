     public static class RadioButtonHelper
     {
        public static MvcHtmlString EnumRadioButtonListFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression)
        {
            ModelMetadata metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
            string name = ExpressionHelper.GetExpressionText(expression);
            Type type = Nullable.GetUnderlyingType(metaData.ModelType);
            if (type == null || !type.IsEnum)
            {
                throw new ArgumentException(string.Format("The property {0} is not an enum", name));
            }
            StringBuilder html = new StringBuilder();
            foreach (Enum item in Enum.GetValues(type))
            {
                string id = string.Format("{0}_{1}", metaData.PropertyName, item);
                StringBuilder innerHtml = new StringBuilder();
                innerHtml.Append(helper.RadioButtonFor(expression, item, new { id = id }));
                innerHtml.Append(helper.Label(id, item.ToDescription()));
                TagBuilder div = new TagBuilder("div");
                div.AddCssClass("radiobutton");
                div.InnerHtml = innerHtml.ToString();
                html.Append(div.ToString());
            }
            TagBuilder container = new TagBuilder("div");
            container.AddCssClass("radiobutton-container");
            container.InnerHtml = html.ToString();
            return MvcHtmlString.Create(container.ToString());
        }
    }
