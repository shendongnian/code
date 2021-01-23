    public class PropertyInfoTemplateSelector : DataTemplateSelector
    {
        public DataTemplate StringTemplate { get; set; }
        public DataTemplate IntegerTemplate { get; set; }
        public DataTemplate DecimalTemplate { get; set; }
        public DataTemplate BooleanTemplate { get; set; }
        public DataTemplate DefaultTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            PropertyInfo propertyInfo = item as PropertyInfo;
            if (propertyInfo.PropertyType == typeof(string))
            {
                return StringTemplate;
            }
            else if (propertyInfo.PropertyType == typeof(int))
            {
                return IntegerTemplate;
            }
            else if (propertyInfo.PropertyType == typeof(float) || propertyInfo.PropertyType == typeof(double))
            {
                return DecimalTemplate;
            }
            else if (propertyInfo.PropertyType == typeof(bool))
            {
                return BooleanTemplate;
            }
            return DefaultTemplate;
        }
    }
