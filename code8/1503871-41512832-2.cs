    //...
    dataTreeView.CellEditStarting += DisableInputValueForCollections;
    //...
    		private static void DisableInputValueForCollections(object sender, CellEditEventArgs e)
    		{
    			RemoveExtraOffsetForNotFirstColumnInputControl(e);
    			var node = e.RowObject as DataTreeNode;
    			
    			if (node != null && e.Column.AspectName == "Value")
    			{
    				if (node.IsContainer()) e.Cancel = true;
    			}
    		}
    //...
    private static void RemoveExtraOffsetForNotFirstColumnInputControl(CellEditEventArgs e)
    		{
    			if (e.Column.AspectName != "Name")
    			{
    				e.Control.Bounds = e.CellBounds;
    			}
    		}
    //...
