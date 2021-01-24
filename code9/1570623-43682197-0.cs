    ...
    Using System.Web.Mvc.Html;
    public static IHtmlContent HiddenFormFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TResult>> expression,
            string buttonDescription)
    {
       
        MvcForm form = FormExtensions.BeginForm(htmlHelper);
        ... // fill the form and return its content
    }
