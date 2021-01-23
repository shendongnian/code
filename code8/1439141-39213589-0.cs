        public static MvcHtmlString ErrorBlock<TModel>(this HtmlHelper helper, TModel model, 
            string @class = null, object context = null, string view = null, object attributes = null, 
            Func<ErrorModel, Func<ErrorModel,IHtmlString>> errorTemplate = null)
            where TModel : BaseModel
        {
        ...
            if (errorTemplate != null)
            {
                var formattedErrors = errors.Select(e => errorTemplate?.Invoke(e)?.Invoke(e)?.ToHtmlString() ?? string.Empty);
                tb.InnerHtml = string.Join("", formattedErrors);
            }
        }
        ....
