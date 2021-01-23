    public class MultiSelectTreeViewItem : TreeViewItem
    {
        object _originalHeader;
        protected override void OnHeaderChanged(object oldHeader, object newHeader)
        {
            base.OnHeaderChanged(oldHeader, newHeader);
            //.NET 4.5 use BindingOperations.DisconnectedSource
    	    if (newHeader.ToString() != "{DisconnectedItem}")
    	        _originalHeader = newHeader;
        }
    
        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);
    
    	    if (Header.ToString() == "{DisconnectedItem}" && _originalHeader != null && e.Action == NotifyCollectionChangedAction.Reset)
    	    {
                //Find the parent Tree View and remove this from MultiSelectedList
            }
        }
    
    
        protected override DependencyObject GetContainerForItemOverride()
        {
    	    return new MultiSelectTreeViewItem();
        }
    
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
    	    return item is MultiSelectTreeViewItem;
        }
    }
