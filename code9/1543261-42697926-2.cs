    public class MyTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var elem = container as FrameworkElement;
            if (item == null || elem == null)
            {
                return null;
            }
            var t = item.GetType();
            var prop = t.GetProperty("PropertyValue");
            if (prop == null)
            {
                return null;
            }
            // select template by the type of the PropertyValue parameter
            if (typeof(bool?).IsAssignableFrom(prop.PropertyType))
            {
                return elem.FindResource("BooleanContextTemplate") as DataTemplate;
            }
            if (typeof(string).IsAssignableFrom(prop.PropertyType))
            {
                return elem.FindResource("StringContextTemplate") as DataTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
