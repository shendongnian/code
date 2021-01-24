    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    
    namespace System.Web.Mvc.Html
    {
        public static class EnumHelpers
        {
            public static MvcHtmlString EnumRadioButtonListFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, ListDirection listDirection)
            {
                ModelMetadata metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
                string name = ExpressionHelper.GetExpressionText(expression);
                if (!metaData.ModelType.IsEnum)
                {
                    throw new ArgumentException(string.Format("The property {0} is not an enum", name));
                }
    
                var dictionary = Enum.GetValues(metaData.ModelType).Cast<object>().ToDictionary(k => (int)k, v => ((Enum)v).ToString());
                StringBuilder html = new StringBuilder();
    
                foreach (KeyValuePair<int, string> entry in dictionary)
                {
                    html.Append(String.Format(@"
    <label class=""{3}"" for=""{0}-{1}"">
        <input type=""radio"" name=""{0}"" id=""{0}-{1}"" value=""{1}"">
        {2}
    </label>",
                    new string[]
                    {
                        metaData.ModelType.Name,
                        entry.Key.ToString(),
                        entry.Value,
                        listDirection == ListDirection.Horizontal ? "radio-inline" : "radio"
                    }));
                }
    
                return MvcHtmlString.Create(html.ToString());
            }
    
            public enum ListDirection
            {
                Vertical,
                Horizontal
            }
        }
    }
