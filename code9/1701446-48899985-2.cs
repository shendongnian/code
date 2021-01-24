    public class ComboBoxItemTemplateSelector:DataTemplateSelector
    {
        public DataTemplate DropDownTemplate
        {
            get;
            set;
        }
        public DataTemplate SelectedTemplate
        {
            get;
            set;
        }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            ComboBoxItem comBoxItem = GetParent<ComboBoxItem>(container);
            if (comBoxItem != null)
            {
                return DropDownTemplate;
            }
            return SelectedTemplate;
        }
       internal static T GetParent<T>(object childobject) where T:DependencyObject
        {
            DependencyObject child = childobject as DependencyObject;
            while ((child != null) && !(child is T))
            {
                child = VisualTreeHelper.GetParent(child);
            }
            return child as T;
        }
    }
