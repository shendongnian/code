    public static IEnumerable<T> SeachUiElementsByTypo<T>(DependencyObject depObj) where T : DependencyObject
		{
			if (depObj != null)
			{
				for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
				{
					DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
					if (child != null && child is T)
					{
						yield return (T)child;
					}
					foreach (T childOfChild in SeachUiElementsByTypo<T>(child))
					{
						yield return childOfChild;
					}
				}
			}
		}
