	public class CustomDataTemplateSelector : DataTemplateSelector
	{
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			if (item is MainWindow.Picture)
				return PictureTemplate;
			if (item is MainWindow.Parameter)
				return ParameterTemplate;
			// return some default template as fall-back
		}
		public DataTemplate PictureTemplate { get; set; }
		public DataTemplate ParameterTemplate { get; set; }
		// ...add other template references here...
	}
