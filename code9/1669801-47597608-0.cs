	public interface IMyTreeViewItem
    {
        bool TreeViewItemIsSelected { get; set; }
        bool TreeViewItemIsExpanded { get; set; }
		
		// Further potential properties
		
		string TreeViewItemHeaderText { get; set; }
		List<IMyTreeViewItem> TreeViewItemChildren { get; set; }
    }
	
