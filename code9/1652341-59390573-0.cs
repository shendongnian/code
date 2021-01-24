    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    /// <summary>
    /// A class that defines extension methods for a HTML helper.
    /// </summary>
    public static class HtmlHelperExtensions
    {
        #region Methods
        #region _Private_
        private static MvcHtmlString DisableDropDownItem(MvcHtmlString source, string sourceItemName, string sourceItemValue = "", string targetItemValue = "")
        {
            string htmlString;
            MvcHtmlString returnValue;
            string sourceString;
            sourceString = $"<option value=\"{sourceItemValue}\">{sourceItemName}</option>";
            htmlString = source.ToHtmlString();
            if (htmlString.Contains(sourceString))
            {
                string replaceString;
                replaceString = $"<option value=\"{targetItemValue}\" disabled=\"disabled\" selected=\"selected\">{sourceItemName}</option>";
                htmlString = htmlString.Replace(sourceString, replaceString);
            }
            returnValue = new MvcHtmlString(htmlString);
            return returnValue;
        }
        #endregion
        #region _Public_
        /// <summary>
        /// Returns an HTML select element for each property in the object that is represented by the specified expression using the specified list items, and option label, with the opton label disabled.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the value.</typeparam>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="selectList">An IEnumerable of SelectListItem objects that are used to populate the drop-down list.</param>
        /// <param name="optionLabel">A string containing the text for a default empty item. This parameter can be null.</param>
        /// <param name="optionLabelValue">A string containing the value that should be assigned to the option label.</param>
        /// <returns>An HTML select element for each property in the object that is represented by the expression.</returns>
        public static MvcHtmlString DropDownListWithDisabledFirstItemFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, int optionLabelValue = 0)
        {
            return DisableDropDownItem(htmlHelper.DropDownListFor(expression, selectList, optionLabel), optionLabel, string.Empty, optionLabelValue.ToString());
        }
        /// <summary>
        /// Returns an HTML select element for each property in the object that is represented by the specified expression using the specified list items, option label, and HTML attributes, with the opton label disabled.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the value.</typeparam>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="selectList">An IEnumerable of SelectListItem objects that are used to populate the drop-down list.</param>
        /// <param name="optionLabel">A string containing the text for a default empty item. This parameter can be null.</param>
        /// <param name="htmlAttributes">An IDictionary of key string and value object that contains the HTML attributes to set for the element.</param>
        /// <param name="optionLabelValue">A string containing the value that should be assigned to the option label.</param>
        /// <returns>An HTML select element for each property in the object that is represented by the expression.</returns>
        public static MvcHtmlString DropDownListWithDisabledFirstItemFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, IDictionary<string, object> htmlAttributes, int optionLabelValue = 0)
        {
            return DisableDropDownItem(htmlHelper.DropDownListFor(expression, selectList, optionLabel, htmlAttributes), optionLabel, string.Empty, optionLabelValue.ToString());
        }
        /// <summary>
        /// Returns an HTML select element for each property in the object that is represented by the specified expression using the specified list items, option label, and HTML attributes, with the opton label disabled.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the value.</typeparam>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to display.</param>
        /// <param name="selectList">An IEnumerable of SelectListItem objects that are used to populate the drop-down list.</param>
        /// <param name="optionLabel">A string containing the text for a default empty item. This parameter can be null.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <param name="optionLabelValue">A string containing the value that should be assigned to the option label.</param>
        /// <returns>An HTML select element for each property in the object that is represented by the expression.</returns>
        public static MvcHtmlString DropDownListWithDisabledFirstItemFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes, string optionLabelValue = "0")
        {
            return DisableDropDownItem(htmlHelper.DropDownListFor(expression, selectList, optionLabel, htmlAttributes), optionLabel, string.Empty, optionLabelValue);
        }
        #endregion
        #endregion
    }
