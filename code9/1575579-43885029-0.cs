        public static MvcHtmlString MyTextBox(this HtmlHelper html, CustomModelEditor property, object additionalViewData = null)
            {
    
                dynamic htmlattr = additionalViewData ?? new ExpandoObject();
    
                htmlattr.@class = "form-control";
                htmlattr.type = property.InputType.ToString().ToLower();
    
                if (property.IsRequired)
                    htmlattr.required = "required";
                if (property.IsReadonly)
                    htmlattr.@readonly = "readonly";
                if (property.IsDisabled)
                    htmlattr.disabled = "disabled";
                if (property.Length != 0)
                    htmlattr.maxlength = property.Length;
                if (property.Value == null)
                    property.Value = property.DefaultValue;
    
                htmlattr.value = property.Value;
    
                return InputExtensions.TextBox(html, property.Name, property.Value, htmlattr);
            }
