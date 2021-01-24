    private void dataGrid_Scroll(object sender, RoutedEventArgs e)
		{
			ScrollEventArgs scrollEvent = e as ScrollEventArgs;
			if (scrollEvent != null)
			{
				if (scrollEvent.ScrollEventType == ScrollEventType.EndScroll)
				{
					isScrolling = false;
				}
				else
				{
					isScrolling = true;
				}
			}
		}
