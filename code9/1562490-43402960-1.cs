    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Given an input property, creates a full block of:
        /// 1. checkbox (to allow toggle)
        /// 2. label
        /// 3. extra content if needed (shown above the textbox)
        /// 4. textbox
        /// 5. validation message
        /// 
        /// 3+4+5 are shown only if the checkbox is clicked (toggle functionality)
        /// </summary>
        public static IHtmlContent FullGroupFor<TModel, TResult>(
            this IHtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TResult>> expression,
            string placeholder = null,
            IHtmlContent extraContent = null)
        {            
            var propertyId = string.Join("_", expression.Body.ToString().Split('.').Skip(1));
            var method = expression.Compile();
            var value = method(htmlHelper.ViewData.Model);
            var hasValue = (value != null);
            var builder = new HtmlContentBuilder();
            builder.AppendHtml("<div class=\"form-group\">");
            builder.AppendHtml($"<input type=\"checkbox\" id=\"{propertyId}-toggler\" {(hasValue ? "checked" : "")} onchange=\"return toggleProperty(this)\"/>");
            builder.AppendHtml("&nbsp");
            builder.AppendHtml(htmlHelper.LabelFor<TResult>(expression, null, null));
            builder.AppendHtml($"<div id=\"{propertyId}-inputdiv\" style=\"display:{(hasValue ? "" : "none")}\">");
            if (extraContent != null)
                builder.AppendHtml(extraContent);
            builder.AppendHtml(htmlHelper.TextBoxFor(expression, new { @class = "form-control", placeholder = placeholder }));
            builder.AppendHtml(htmlHelper.ValidationMessageFor(expression));
            builder.AppendHtml("</div>");
            builder.AppendHtml("</div>");
            return builder;
        }
        /// <summary>
        /// Javascript code necessary to run the toggle code in the previous function.
        /// </summary>
        public static IHtmlContent GetToggleScript(this IHtmlHelper htmlHelper)
            => new HtmlString(@"
                <script>
                    var toggleProperty = function(targetCheckbox) {
                        var id = targetCheckbox.id.split('-')[0];
                        var inputDiv = document.getElementById(id + '-inputdiv');
                        inputDiv.style.display = (inputDiv.style.display !== 'none') ? 'none' : '';
                    }
                </script>
            ");
    }
