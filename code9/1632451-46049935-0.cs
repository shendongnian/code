    public static object GetObjectAtPoint<ItemContainer>(this ItemsControl control, Point p)
                                         where ItemContainer : DependencyObject
            {
                // ItemContainer - can be ListViewItem, or TreeViewItem and so on(depends on control) 
                ItemContainer obj = GetContainerAtPoint<ItemContainer>(control, p);
                if (obj == null)
                    return null;
    
                return control.ItemContainerGenerator.ItemFromContainer(obj);
            }
    
            public static ItemContainer GetContainerAtPoint<ItemContainer>(this ItemsControl control, Point p)
                                     where ItemContainer : DependencyObject
            {
                HitTestResult result = VisualTreeHelper.HitTest(control, p);
    			if (result != null)
    			{
    				DependencyObject obj = result.VisualHit;
    
    				while (VisualTreeHelper.GetParent(obj) != null && !(obj is ItemContainer))
    				{
    					obj = VisualTreeHelper.GetParent(obj);
    				}
    
    				// Will return null if not found 
    				return obj as ItemContainer;
    			}
    			else return null;
            } 
