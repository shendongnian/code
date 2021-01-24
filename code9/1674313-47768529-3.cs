    using System.Linq.Expressions;
    using System.Text;
    
    namespace System.Web.Mvc.Html
    {
        public static class EnumHelpers
        {
            public static MvcHtmlString EnumRadioButtonListFor<TModel, TValue>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TValue>> expression, ListDirection listDirection)
            {
                ModelMetadata metaData = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);
                string enumName = ExpressionHelper.GetExpressionText(expression);
                if (!metaData.ModelType.IsEnum)
                    throw new ArgumentException(string.Format("The property {0} is not an enum", enumName));
    
                var html = new StringBuilder();
    
                foreach (int i in Enum.GetValues(metaData.ModelType))
                {
                    var name = Enum.GetName(metaData.ModelType, i);
    
                    string id = string.Format("{0}_{1}", enumName, name);
                    html.Append(String.Format("<label class=\"{1}\" for=\"{0}\">",
                        new string[] {
                                    id,
                                    listDirection == ListDirection.Horizontal ? "radio-inline" : "radio"
                                }));
                    html.Append(helper.RadioButtonFor(expression, i, new { id = id }));
                    html.Append(String.Format(" {0}</label>", name));
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
