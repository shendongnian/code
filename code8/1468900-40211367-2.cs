    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (value==1) {
            StyleRefExt sr = new StyleRefExt {ResourceKey = "ControlTemplateName1"};
            return sr.ProvideValue();
        }
        if (value==2) {
            StyleRefExt sr = new StyleRefExt {ResourceKey = "ControlTemplateName2"};
            return sr.ProvideValue();
        }
    }
