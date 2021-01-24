    public static MvcHtmlString Control<TModel>(this MyHtmlHelper<TModel> helper, string propertyName,
        LayoutHelper layout, TemplateType templateType = TemplateType.Screen) {
        Expression<Func<TModel, string>> expression = GetPropertyExpression<TModel>(propertyName);
        var propertyMetadata = ModelMetadata.FromStringExpression(expression, helper.Html.ViewData);
        //...other code...
    }
