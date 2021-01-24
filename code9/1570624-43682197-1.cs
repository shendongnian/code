    ...
    Using System.Web.Mvc.Html;
    public static IHtmlContent HiddenFormFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression,
            string buttonDescription)
    {
       
        FormExtensions.BeginForm(htmlHelper); //adding <form> to htmlhelper
        htmlHelper.HiddenFor(expression); //Add hidden value
        FormExtensions.EndForm(htmlHelper); //adding </form> to htmlHelper
        ...
    }
