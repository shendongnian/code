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
    
                string name = ExpressionHelper.GetExpressionText(expression);
                string[] names = Enum.GetNames(metaData.ModelType);
                foreach (string value in names)
                {
                    string id = string.Format("{0}_{1}", name, value);
                    html.Append(String.Format("<label class=\"{1}\" for=\"{0}\">",
                        new string[] {
                                        id,
                                        listDirection == ListDirection.Horizontal ? "radio-inline" : "radio"
                                }));
                    html.Append(helper.RadioButtonFor(expression, value, new { id = id }));
                    html.Append(String.Format(" {0}</label>", value));
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
