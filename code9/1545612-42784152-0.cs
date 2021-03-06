	public static class Utils
	{
		public static Visual GetDescendantByType(Visual element, Type type)
		{
			if (element == null)
				return null;
			
			if (element.GetType() == type)
				return element;
			
			Visual foundElement = null;
			if (element is FrameworkElement)
				(element as FrameworkElement).ApplyTemplate();
			
			for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
			{
				Visual visual = VisualTreeHelper.GetChild(element, i) as Visual;
				foundElement = GetDescendantByType(visual, type);
				if (foundElement != null)
					break;
			}
			return foundElement;
		}
	}
	
