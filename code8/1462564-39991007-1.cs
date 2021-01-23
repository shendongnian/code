    internal static string BooleanTemplate(HtmlHelper html)
    {
      bool? nullable1 = new bool?();
      if (html.ViewContext.ViewData.Model != null)
        nullable1 = new bool?(Convert.ToBoolean(html.ViewContext.ViewData.Model, (IFormatProvider) CultureInfo.InvariantCulture));
      if (html.ViewContext.ViewData.ModelMetadata.IsNullableValueType)
        return DefaultEditorTemplates.BooleanTemplateDropDownList(html, nullable1);
      HtmlHelper html1 = html;
      bool? nullable2 = nullable1;
      int num = nullable2.HasValue ? (nullable2.GetValueOrDefault() ? 1 : 0) : 0;
      return DefaultEditorTemplates.BooleanTemplateCheckbox(html1, num != 0);
    }
    
    private static string BooleanTemplateCheckbox(HtmlHelper html, bool value)
    {
      return InputExtensions.CheckBox(html, string.Empty, value, DefaultEditorTemplates.CreateHtmlAttributes(html, "check-box", (string) null)).ToHtmlString();
    }
    
    private static string BooleanTemplateDropDownList(HtmlHelper html, bool? value)
    {
      return SelectExtensions.DropDownList(html, string.Empty, (IEnumerable<SelectListItem>) DefaultEditorTemplates.TriStateValues(value), DefaultEditorTemplates.CreateHtmlAttributes(html, "list-box tri-state", (string) null)).ToHtmlString();
    }
