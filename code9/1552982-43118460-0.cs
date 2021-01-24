    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    
    public class SelectOnRMBBehavior : Behavior<FrameworkElement>
    {
    	public static readonly DependencyProperty CurrentItemProperty = DependencyProperty.Register("CurrentItem", typeof(TreeViewItem), typeof(SelectOnRMBBehavior), new PropertyMetadata(null));
    	
    	public TreeViewItem CurrentItem
    	{
    		get
    		{
    			return (TreeViewItem)GetValue(CurrentItemProperty);
    		}
    		set
    		{
    			SetValue(CurrentItemProperty, value);
    		}
    	}
    
    	protected override void OnAttached()
    	{
    		base.OnAttached();
    
    		AssociatedObject.PreviewMouseRightButtonDown += AssociatedObject_PreviewMouseRightButtonDown;
    	}
    
    	private void AssociatedObject_PreviewMouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    	{
    		if (CurrentItem!=null)
    		{
    			CurrentItem.IsSelected = true;
    		}
    	}
    	
    	protected override void OnDetaching()
    	{
    		AssociatedObject.PreviewMouseRightButtonDown -= AssociatedObject_PreviewMouseRightButtonDown;
    
    		base.OnDetaching();
    	}
    }
	
