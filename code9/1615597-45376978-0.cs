    public class TemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is IA)
                return (DataTemplate)((FrameworkElement)container).FindResource("ia");
            return base.SelectTemplate(item, container);
        }
    }
