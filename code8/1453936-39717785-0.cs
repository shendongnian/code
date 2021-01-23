    private void UltraGrid1_AfterRowActivate(object sender, EventArgs e)
    {
        var grid = sender as UltraGrid;
        if(grid == null)
            return;
    
        //  Get the element where user clicked
        var element = grid.DisplayLayout.UIElement.ElementFromPoint(grid.PointToClient(Cursor.Position));
    
        //  Check if the element is CheckIndicatorUIElement. If so the user clicked exactly
        //  on the check box. The element's parent should be CheckEditorCheckBoxUIElement
        CheckEditorCheckBoxUIElement checkEditorCheckBoxElement = null;
        if(element is CheckIndicatorUIElement)
        {
            checkEditorCheckBoxElement = element.Parent as CheckEditorCheckBoxUIElement;
        }
        //  Check if the element is CheckEditorCheckBoxUIElement. If so the user clicked
        //  on a check box cell, but not on the check box
        else if(element is CheckEditorCheckBoxUIElement)
        {
            checkEditorCheckBoxElement = element as CheckEditorCheckBoxUIElement;
        }
    
        //  If checkEditorCheckBoxElement is not null check box cell was clicked
        if(checkEditorCheckBoxElement != null)
        {
            //  You can get the cell from the parent of the parent of CheckEditorCheckBoxUIElement
            //  Here is the hierarchy:
            //  CellUIElement
            //      EmbeddableCheckUIElement
            //          CheckEditorCheckBoxUIElement
            //              CheckIndicatorUIElement
            //  Find the CellUIElement and get the Cell of it
    
            if(checkEditorCheckBoxElement.Parent != null && checkEditorCheckBoxElement.Parent.Parent != null)
            {
                var cellElement = checkEditorCheckBoxElement.Parent.Parent as CellUIElement;
                if(cellElement != null)
                {
                    var cell = cellElement.Cell;
                }
            }
        }
    }
