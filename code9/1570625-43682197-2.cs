    ...
    Using System.Web.Mvc.Html;
    public static IHtmlContent HiddenFormFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression,
            string buttonDescription)
    {
        var content = new StringBuilder();
        content.Append(FormExtensions.BeginForm(htmlHelper)); //adding <form> to htmlhelper
        content.append(htmlHelper.HiddenFor(expression)); //Add hidden value
        content.append(FormExtensions.EndForm(htmlHelper)); //adding </form> to htmlHelper
        return MvcHtmlString.Create(content.ToString());
    }
