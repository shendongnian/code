    public static MvcHtmlString NumericRangeInputFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
    {
        // Add type="number"
        var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
        attributes.Add("type", "number");
        // Check for a [Range] attribute
        ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
        var property = metadata.ContainerType.GetProperty(metadata.PropertyName);
        RangeAttribute range = property.GetCustomAttributes(typeof(RangeAttribute), false).First() as RangeAttribute;
        if (range != null)
        {
            attributes.Add("min", range.Minimum);
            attributes.Add("max", range.Maximum);
        }
        return helper.TextBoxFor(expression, attributes);
    }
