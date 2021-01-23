    private static readonly Dictionary<string, Func<HtmlHelper, string>> _defaultEditorActions = new Dictionary<string, Func<HtmlHelper, string>>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)
        {
          {
            "HiddenInput",
            new Func<HtmlHelper, string>(DefaultEditorTemplates.HiddenInputTemplate)
          },
          {
            "MultilineText",
            new Func<HtmlHelper, string>(DefaultEditorTemplates.MultilineTextTemplate)
          },
          {
            "Password",
            new Func<HtmlHelper, string>(DefaultEditorTemplates.PasswordTemplate)
          },
          {
            "Text",
            new Func<HtmlHelper, string>(DefaultEditorTemplates.StringTemplate)
          },
          {
            "Collection",
            new Func<HtmlHelper, string>(DefaultEditorTemplates.CollectionTemplate)
          },
          {
            "PhoneNumber",
            new Func<HtmlHelper, string>(DefaultEditorTemplates.PhoneNumberInputTemplate)
          },
          {
            "Url",
            new Func<HtmlHelper, string>(DefaultEditorTemplates.UrlInputTemplate)
          },
          {
            "EmailAddress",
            new Func<HtmlHelper, string>(DefaultEditorTemplates.EmailAddressInputTemplate)
          },
          {
            "DateTime",
            new Func<HtmlHelper, string>(DefaultEditorTemplates.DateTimeInputTemplate)
          },
          {
            "DateTime-local",
            new Func<HtmlHelper, string>(DefaultEditorTemplates.DateTimeLocalInputTemplate)
          },
          {
            "Date",
            new Func<HtmlHelper, string>(DefaultEditorTemplates.DateInputTemplate)
          },
          {
            "Time",
            new Func<HtmlHelper, string>(DefaultEditorTemplates.TimeInputTemplate)
          },
          {
            typeof (Color).Name,
            new Func<HtmlHelper, string>(DefaultEditorTemplates.ColorInputTemplate)
          },
          {
            typeof (byte).Name,
            new Func<HtmlHelper, string>(DefaultEditorTemplates.NumberInputTemplate)
          },
          {
            typeof (sbyte).Name,
            new Func<HtmlHelper, string>(DefaultEditorTemplates.NumberInputTemplate)
          },
          {
            typeof (int).Name,
            new Func<HtmlHelper, string>(DefaultEditorTemplates.NumberInputTemplate)
          },
          {
            typeof (uint).Name,
            new Func<HtmlHelper, string>(DefaultEditorTemplates.NumberInputTemplate)
          },
          {
            typeof (long).Name,
            new Func<HtmlHelper, string>(DefaultEditorTemplates.NumberInputTemplate)
          },
          {
            typeof (ulong).Name,
            new Func<HtmlHelper, string>(DefaultEditorTemplates.NumberInputTemplate)
          },
          {
            typeof (bool).Name,
            new Func<HtmlHelper, string>(DefaultEditorTemplates.BooleanTemplate)
          },
          {
            typeof (Decimal).Name,
            new Func<HtmlHelper, string>(DefaultEditorTemplates.DecimalTemplate)
          },
          {
            typeof (string).Name,
            new Func<HtmlHelper, string>(DefaultEditorTemplates.StringTemplate)
          },
          {
            typeof (object).Name,
            new Func<HtmlHelper, string>(DefaultEditorTemplates.ObjectTemplate)
          }
        };
