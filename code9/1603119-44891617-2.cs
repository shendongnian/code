    public class DynamicTemplatesList
    {
        public static readonly DependencyProperty TemplatesProperty =
            DependencyProperty.RegisterAttached(
                "Templates",
                typeof(TemplateCollection),
                typeof(DynamicTemplatesList));
         public static TemplateCollection GetTemplates(UIElement element)
         {
             return (TemplateCollection)element.GetValue(TemplatesProperty);
         }
         public static void SetTemplates(UIElement element, TemplateCollection collection)
         {
             element.SetValue(TemplatesProperty, collection);
         }
    }
