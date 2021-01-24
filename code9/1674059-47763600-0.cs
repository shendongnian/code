	public class ViewSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (element != null && item != null && item is ObservableObject)
            {
                ObservableObject oo = item as ObservableObject;
                if (oo.GetType() == typeof(SubViewModel))
                {
                    return (DataTemplate)Application.Current.Resources["subviewmodel_template"];
                }
            }
            return null;
        }
    }
	
