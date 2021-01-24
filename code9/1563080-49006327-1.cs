        public static class LabelHelpers
        {
         public static MvcHtmlString LabelForCamelCase<T, TResult>(this HtmlHelper<T> helper, Expression<Func<T, TResult>> expression, object htmlAttributes = null)
          {
            string propertyName = CustomHTMLHelperUtilities.PropertyName(expression);
            string labelValue = CustomHTMLHelperUtilities.SplitCamelCase(propertyName);
            #region Html attributes creation
            var builder = new TagBuilder("label ");
            builder.Attributes.Add("text", labelValue);
            builder.Attributes.Add("for", propertyName);
            #endregion
            #region additional html attributes
            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                builder.MergeAttributes(attributes);
            }
            #endregion
            MvcHtmlString retHtml = new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
            return retHtml;
            
          }
        }
