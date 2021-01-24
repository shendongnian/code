    void Popup_OnLoaded(object sender, RoutedEventArgs e)
    		{
    			var itemsPresenter = (ItemsPresenter) FindChild(MyItemsControl, typeof(ItemsPresenter));
    			itemsPresenter.InvalidateMeasure();
    		}
    public DependencyObject FindChild(DependencyObject o, Type childType)
        		{
        			DependencyObject foundChild = null;
        			if (o != null)
        			{
        				var childrenCount = VisualTreeHelper.GetChildrenCount(o);
        				for (var i = 0; i < childrenCount; i++)
        				{
        					var child = VisualTreeHelper.GetChild(o, i);
        					if (child.GetType() != childType)
        					{
        						foundChild = FindChild(child, childType);
        					}
        					else
        					{
        						foundChild = child;
        						break;
        					}
        				}
        			}
        			return foundChild;
        		}
