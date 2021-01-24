    private void TabControl_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    		{
    			if ((sender as TabControl)!=null)
    			{
    				var yourCtl = GetChildren<drawingBoard.DrawingBoard>((sender as TabControl)).FirstOrDefault() as drawingBoard.DrawingBoard;
    			}
    		}
    
    		IEnumerable<T> GetChildren<T>(FrameworkElement parent) where T : FrameworkElement
    		{
    			var chCount = VisualTreeHelper.GetChildrenCount(parent);
    			for (int i = 0; i < chCount; i++)
    			{
    				var child = VisualTreeHelper.GetChild(parent, i);
    				if (child is T)
    				{	
    					yield return child as T;
    				}
    				if (child is FrameworkElement)
    				{
    					foreach (var item in GetChildren<T>(child as FrameworkElement))
    					{
    						yield return item;
    					};
    				}
    			}
    		}
