    #region Bootstrap/HTML 5 Radio Button
        /// <summary>
        /// Bootstrap and HTML 5 Radio Button.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="id">The 'id' attribute name to set.</param>
        /// <param name="name">The 'name' attribute to set.</param>
        /// <param name="text">The text to display next to this radio button.</param>
        /// <param name="value">The 'value' attribute to set.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML radio button with the appropriate type set.</returns>
        public static MvcHtmlString RadioButtonBootstrapFor<TModel, TValue>(
              this HtmlHelper<TModel> htmlHelper,
              Expression<Func<TModel, TValue>> expression,
              string id,
              string name,
              string text,
              string value,
              object htmlAttributes = null)
        {
          return RadioButtonBootstrapFor(htmlHelper, expression, id, name, text, value, false, false, false, htmlAttributes);
        }
    
        /// <summary>
        /// Bootstrap and HTML 5 Radio Button in a Button Helper.
        /// This helper assumes you have added the appropriate CSS to style this radio button.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the properties to render.</param>
        /// <param name="id">The 'id' attribute name to set.</param>
        /// <param name="name">The 'name' attribute to set.</param>
        /// <param name="text">The text to display next to this radio button.</param>
        /// <param name="value">The 'value' attribute to set.</param>
        /// <param name="isChecked">Whether or not to set the 'checked' attribute on this radio button.</param>
        /// <param name="isAutoFocus">Whether or not to set the 'autofocus' attribute on this radio button.</param>
        /// <param name="useInline">Whether or not to use 'radio-inline' for the Bootstrap class.</param>
        /// <param name="htmlAttributes">An object that contains the HTML attributes to set for the element.</param>
        /// <returns>An HTML radio button with the appropriate type set.</returns>
        public static MvcHtmlString RadioButtonBootstrapFor<TModel, TValue>(
          this HtmlHelper<TModel> htmlHelper,
          Expression<Func<TModel, TValue>> expression,
          string id,
          string name,
          string text,
          string value,
          bool isChecked,
          bool isAutoFocus,
          bool useInline = false,
          object htmlAttributes = null)
        {
          StringBuilder sb = new StringBuilder(512);
          string htmlChecked = string.Empty;
          string htmlAutoFocus = string.Empty;
          string rdoClass = "radio";
    
          if (isChecked)
          {
            htmlChecked = "checked='checked'";
          }
          if (isAutoFocus)
          {
            htmlAutoFocus = "autofocus='autofocus'";
          }
          if (useInline)
          {
            rdoClass = "radio-inline";
          }
    
          // Build the Radio Button
          sb.AppendFormat("<div class='{0}'>", rdoClass);
          sb.Append("  <label>");
          sb.AppendFormat("    <input id='{0}' name='{1}' type='radio' value='{2}' {3} {4} {5} />", 
                          id, name, value, htmlChecked, htmlAutoFocus, 
                          GetHtmlAttributes(htmlAttributes));
          sb.AppendFormat("    {0}", text);
          sb.Append("  </label>");
          sb.Append("</div>");
    
          // Return an MVC HTML String
          return MvcHtmlString.Create(sb.ToString());
        }
        #endregion
