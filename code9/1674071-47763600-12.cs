	public class ViewSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (container is FrameworkElement element && item is SubViewModel svm)
			{
				return element.FindResource("subviewmodel_template") as DataTemplate;
			}
			return null;
		}
    }
	
