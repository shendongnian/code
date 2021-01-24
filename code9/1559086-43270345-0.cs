    public class MyItemsControl : ItemsControl
    {
    	protected override DependencyObject GetContainerForItemOverride()
    	{
    		return ItemTemplate?.LoadContent() ?? base.GetContainerForItemOverride();
    	}
    
    	protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
    	{
    		((FrameworkElement) element).DataContext = item;
    	}
    }
